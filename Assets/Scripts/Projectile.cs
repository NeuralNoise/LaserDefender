using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Projectile : Weapon , IFirable
{
    public float speed;
    public AudioClip fireSound;

    public void Fire()
    {
        GetComponent<Rigidbody2D>().velocity = speed * transform.up;
        AudioSource.PlayClipAtPoint(fireSound, transform.position,0.8f);
    }

    protected override void Hit(Collider2D target)
    {
        base.Hit(target);
        Destroy();
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Hit(collider);
    }


}
