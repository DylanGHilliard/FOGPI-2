using UnityEngine;

public class Pistol : Weapon
{
    
    public override void Use()
    {
        if(time > 1/fireRate)
        {
            time = 0f;
            Instantiate(bulletPrefab, transform.position, firePoint.rotation);
        }
        Debug.Log("Pistol fired");
    }

}
