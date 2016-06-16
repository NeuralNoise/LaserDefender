using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 10;
    float padding = 0.5f;
    float xMin;
    float xMax;

	// Use this for initialization
	void Start ()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftMost.x + padding;
        xMax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
	}

    void Move()
    {
        // Calculate displacement.
        float displacement = speed * Time.deltaTime * Input.GetAxis("Horizontal");

        // Clamp the new position.
        float newX = Mathf.Clamp(transform.position.x + displacement, xMin, xMax);

        // Set the position.
        transform.position = new Vector2(newX, transform.position.y);
    }
}
