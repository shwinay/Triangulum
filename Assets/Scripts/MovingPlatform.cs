using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public Transform[] movePoints;
    int currentPoint;
    int speed = 5;

	void Start ()
    {
        transform.position = new Vector3(movePoints[0].position.x, transform.position.y, movePoints[0].position.z);
        currentPoint = 0;
	}
	
	void Update ()
    {
        if (transform.position.x == movePoints[currentPoint].position.x && transform.position.z == movePoints[currentPoint].position.z)
        {
            print("at start point");
            currentPoint++;

            if (currentPoint >= movePoints.Length)
            {
                currentPoint = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoints[currentPoint].position.x, transform.position.y, movePoints[currentPoint].position.z), speed * Time.deltaTime);
	}
}
