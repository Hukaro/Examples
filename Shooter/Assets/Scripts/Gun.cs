using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Projectile projectile;
    public Transform shell;
    public Transform shellEjection;

    MazzleFlash mazzleFlash;

    void Start()
    {
        mazzleFlash = GetComponent<MazzleFlash>();
    }

    public float msBetweenShot = 100;
    public float muzzleVelocity = 35;
    float nextShotTime;
    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShot / 1000;
            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(muzzleVelocity);

            Instantiate(shell, shellEjection.position, shellEjection.rotation);
            //mazzleFlash.Activate();
        }
    }
}