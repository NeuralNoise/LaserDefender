using UnityEngine;
using System.Collections;

public class Enemy : SpaceCraft
{
    protected override void Destroy()
    {
        base.Destroy();
        FindObjectOfType<ScoreKeeper>().Score(100);
    }

    void Update()
    {
        float probability = Time.deltaTime / fireRate;
        if(Random.value < probability)
        {
            Fire();
        }
    }
}
