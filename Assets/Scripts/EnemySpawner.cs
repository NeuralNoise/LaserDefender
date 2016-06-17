using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float padding = 0.5f;
    float xMin,xMax,yMin,yMax;

    void Start ()
    {
        CalculateLimits();
        SpawnEnemies();
	}

	void Update ()
    {
        Move();
	}

    void OnDrawGizmos()
    {
        CalculateLimits();
        Vector3 center = transform.position + 0.5f * new Vector3(xMax + xMin, yMax + yMin, 0);
        Vector3 size = new Vector3(xMax - xMin, yMax - yMin, 0) + 2 * new Vector3(padding, padding, 0);
        Gizmos.DrawWireCube(center, size);
    }
    void CalculateLimits()
    {
        xMin = float.MaxValue;
        xMax = float.MinValue;
        yMin = float.MaxValue;
        yMax = float.MinValue;
        foreach (Transform child in transform)
        {
            float x = child.localPosition.x;
            float y = child.localPosition.y;
            if (x > xMax) xMax = x;
            if (x < xMin) xMin = x;
            if (y > yMax) yMax = y;
            if (y < yMin) yMin = y;
        }
    }  
    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.SetParent(child);
        }
    }
    void Move()
    {
    }
}
