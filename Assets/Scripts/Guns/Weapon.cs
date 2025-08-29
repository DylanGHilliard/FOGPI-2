using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public GameObject bulletPrefab;
    //public Transform firePoint;
    public float fireRate = 1f;
    private float time;

    public virtual void Use() { }
    public virtual void Reload() { }
}
