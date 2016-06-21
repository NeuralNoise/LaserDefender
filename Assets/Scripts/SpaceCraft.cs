using UnityEngine;
using System.Collections;

public class SpaceCraft : Unite
{
    public float fireRate;
    public GameObject projectilePrefab;
    public Vector3 fireStartPoint;
    public Vector3 fireDirection;

    protected void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position + fireStartPoint, Quaternion.Euler(fireDirection)) as GameObject;
        projectile.GetComponent<Projectile>().Fire();
    }
}
