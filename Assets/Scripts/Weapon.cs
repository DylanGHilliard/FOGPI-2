using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float time;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButton("Fire1") && time >= 1f / fireRate)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            time = 0;
        }
    }
}
