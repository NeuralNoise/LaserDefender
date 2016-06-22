using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Unite : MonoBehaviour , IDamageable
{
    public float health;
    public AudioClip deathSound;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy();
        }
    }

    protected virtual void Destroy()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position,10.0f);
        Destroy(gameObject);
    }
}
