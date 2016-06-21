using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public float damage;

    protected virtual void Hit(Collider2D target)
    {
        IDamageable damageable = target.GetComponent<IDamageable>();
        if(damageable != null)
        {
            MakeDamage(damageable);
        }
    }

    void MakeDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);
    }
}
