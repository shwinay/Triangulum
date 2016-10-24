using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    float speed = 5f;
    float lookSensitivity = 5;
    Vector3 input;
    Rigidbody rigidbody;
    int jumpCount;
    Vector3 startPoint;
    private float cameraRotationLimit = 85f;
    Camera cam;
    float xRot;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        input = new Vector3();
        jumpCount = 0;
        startPoint = new Vector3(0, 10, 0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
    }
	

	void FixedUpdate ()
    {
        //get input
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        Vector3 playerRotation = new Vector3(0, Input.GetAxis("Mouse X"), 0) * lookSensitivity;
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(playerRotation));
        transform.Translate(input.normalized * speed * Time.deltaTime);
        
        xRot += Input.GetAxis("Mouse Y") * lookSensitivity;
        xRot = Mathf.Clamp(xRot, -90, 90);
        cam.transform.localEulerAngles = new Vector3(-xRot, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);
        
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

        if (transform.position.y < -20)
        {
            transform.position = startPoint;
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Teleporter")
        {
            Vector3 teleportPoint = other.transform.GetChild(0).transform.position;
            transform.position = new Vector3(teleportPoint.x, teleportPoint.y, teleportPoint.z);
        }

        if (other.tag == "Trampoline")
        {
            rigidbody.AddForce(Vector3.up * 500);
            jumpCount = 1;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Obstacle")
        {
            jumpCount = 0;
        }
        
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Moving Platform")
        {
            jumpCount = 0;
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit(Collision other)
    {
        
        if (other.gameObject.tag == "Moving Platform")
        {
            transform.parent = null;
        }
    }

}
