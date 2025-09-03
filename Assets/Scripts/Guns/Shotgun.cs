using System.Globalization;
using UnityEngine;

public class Shotgun : Weapon
{

    public int numOfBullets;


    public override void Use()
    {
        if (time < 1/fireRate) return;

        for (int i = 0; i < numOfBullets; i++)
        {
            float randomAngle = Random.Range(-15, 15)
;

            Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation*rotation);
            time = 0f;
        }
        Debug.Log("Shotgun fired");
    }
}
