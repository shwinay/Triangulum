using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    float speed = 5f;
    float lookSensitivity = 5;
    Vector3 input;
    Rigidbody rigidbody;
    int jumpCount;

	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        input = new Vector3(0, 0, 0);
        jumpCount = 0;
	}
	

	void FixedUpdate ()
    {

        //get input
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        Vector3 playerRotation = new Vector3(0, Input.GetAxis("Mouse X"), 0) * lookSensitivity;
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(playerRotation));
        transform.Translate(input.normalized * speed * Time.deltaTime);

        Vector3 cameraRotation = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * lookSensitivity;
        Camera.main.transform.Rotate(cameraRotation);

        if (Input.GetButton("Run"))
        {
            speed = 8;
        }
        else
        {
            speed = 5;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (jumpCount < 2)
            {
                rigidbody.AddForce(Vector3.up * 300);
                jumpCount++;
            }
        }
        //FIX ROTATION

        //if (transform.rotation.eulerAngles.x >= 180)
        //{
        //    transform.eulerAngles = new Vector3(180, transform.eulerAngles.y, transform.eulerAngles.z);
        //    print("shifted rot");
        //}

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Teleporter")
        {
            Vector3 teleportPoint = other.transform.GetChild(0).transform.position;
            transform.position = new Vector3(teleportPoint.x, teleportPoint.y, teleportPoint.z);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Obstacle")
        {
            jumpCount = 0;
            
        }
    }

}
