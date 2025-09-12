using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float time;
    public ParticleSystem muzzleFlash;

    public virtual void Use() { }
    public virtual void Reload() { }

    void Awake()
    {
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    
    }

    public void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
    }
}
