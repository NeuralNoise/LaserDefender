using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float speed = 5;

    float padding = 0.5f;
    float leftEdge,rightEdge,botEdge,topEdge;
    float leftEdgeScreen, rightEdgeScreen;
    bool moveRight = true;

    void Start ()
    {
        CalculateScreenEdges();
        CalculateFormationEdges();
        SpawnEnemies();
	}

	void Update ()
    {
        Move();
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
        float displacement = speed * Time.deltaTime;
        if(moveRight)
        {
            transform.position += Vector3.right * displacement;
        }
        else
        {
            transform.position += Vector3.left * displacement;
        }
        float rightEdgeOfFormation = transform.position.x + rightEdge;
        float leftEdgeOfFormation = transform.position.x + leftEdge;
        if(leftEdgeOfFormation < leftEdgeScreen)
        {
            moveRight = true;
        }
        else if(rightEdgeOfFormation > rightEdgeScreen)
        {
            moveRight = false;
        }
    }

    void CalculateFormationEdges()
    {
        leftEdge = float.MaxValue;
        rightEdge = float.MinValue;
        botEdge = float.MaxValue;
        topEdge = float.MinValue;
        foreach (Transform child in transform)
        {
            float x = child.localPosition.x;
            float y = child.localPosition.y;
            if (x > rightEdge) rightEdge = x;
            if (x < leftEdge) leftEdge = x;
            if (y > topEdge) topEdge = y;
            if (y < botEdge) botEdge = y;
        }
        leftEdge -= padding;
        rightEdge += padding;
        botEdge -= padding;
        topEdge += padding;
    }
    void CalculateScreenEdges()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        leftEdgeScreen = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).x;
        rightEdgeScreen = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).x;
    }
    void OnDrawGizmos()
    {
        CalculateFormationEdges();
        Vector3 center = transform.position + 0.5f * new Vector3(rightEdge + leftEdge, topEdge + botEdge, 0);
        Vector3 size = new Vector3(rightEdge - leftEdge, topEdge - botEdge, 0);
        Gizmos.DrawWireCube(center, size);
    }
}
