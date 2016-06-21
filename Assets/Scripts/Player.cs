using UnityEngine;
using System.Collections;

public class Player : SpaceCraft
{
    public float speed = 10;
    float padding = 0.5f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Use this for initialization
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
        xMin = leftMost.x + padding;
        xMax = rightMost.x - padding;
        yMin = leftMost.y + padding;
        yMax = rightMost.y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetButtonDown("Fire"))
        {
            InvokeRepeating("Fire", float.Epsilon, fireRate);
        }
        if(Input.GetButtonUp("Fire"))
        {
            CancelInvoke("Fire");
        }
    }

    void Move()
    {
        // Calculate displacement.
        float Xdisplacement = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float Ydisplacement = speed * Time.deltaTime * Input.GetAxis("Vertical");

        // Clamp the new position.
        float newX = Mathf.Clamp(transform.position.x + Xdisplacement, xMin, xMax);
        float newY = Mathf.Clamp(transform.position.y + Ydisplacement, yMin, yMax);

        // Set the position.
        transform.position = new Vector2(newX, newY);
    }

    protected override void Destroy()
    {
        base.Destroy();
        FindObjectOfType<LevelManager>().LoadNextLevel();
    }
}
