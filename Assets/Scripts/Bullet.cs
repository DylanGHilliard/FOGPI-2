using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>() == null ? gameObject.AddComponent<Rigidbody2D>() : GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        switch (hitInfo.tag)
        {
            case "Enemy":
                Health enemyHealth = hitInfo.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
                Destroy(gameObject);
                break;
            case "Wall":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
