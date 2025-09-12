
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed = 3f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    public GameObject player;
    public int damage = 5;
    private float time = 0;
    public float attackRate;

    [Header("Detection Settings")]
    public float detectionRange = 10;
    public float patrolRadius = 5;
    private bool isChasing;
    private Vector3 randomDriection;

    Seeker seeker;

    Rigidbody2D rb;


    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.Find("Player");

        SetRandomPath();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void SetRandomPath()
    {
        Vector2 randPoint = Random.insideUnitCircle * patrolRadius;
        randomDriection = transform.position + new Vector3(randPoint.x, randPoint.y, 1);
    }
    void UpdatePath()
    {
        if (!seeker.IsDone()) return;

        float disToPlayer = Vector2.Distance(rb.position, player.transform.position);

        if (disToPlayer <= detectionRange)
        {
            isChasing = true;
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        else
        {
            isChasing = false;
            // If reached random destination or no path, set new destination
            if (reachedEndOfPath || path == null)
            {
                SetRandomPath();
            }
            seeker.StartPath(rb.position, randomDriection, OnPathComplete);
        }

    }

    void OnPathComplete(Path _p)
    {
        if (!_p.error)
        {
            path = _p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;

        rb.AddForce(force);
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, speed * 1.5f);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }


        //AttackPlayer
        if ((transform.position - player.transform.position).magnitude < 1.5f && time > 1 / attackRate)
        {

            PlayerManager.instance.health.TakeDamage(damage);
        }

    }



    public void OnDeath()
    {
        PlayerManager.instance.wallet.Earn(5);
        Destroy(this.gameObject);
    }

}
