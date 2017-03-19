using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
    public static int continueScene;
    public static int score;
    gui gameGUI;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        input = new Vector3();
        jumpCount = 0;
        startPoint = GameObject.FindGameObjectWithTag("Start Point").transform.position;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        gameGUI = GameObject.Find("Canvas").GetComponentInChildren<gui>();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            score = 0;
        }

    }
	

	void FixedUpdate ()
    {

        //get input
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        Vector3 playerRotation = new Vector3(0, Input.GetAxis("Mouse X"), 0) * lookSensitivity;
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(playerRotation));
        transform.Translate(input.normalized * speed * Time.deltaTime);
        
        
        
        if (Input.GetButton("Run"))
        {
            speed = 8;
        }
        else
        {
            speed = 5;
        }

        if (transform.position.y < -10)
        {
            continueScene = SceneManager.GetActiveScene().buildIndex;
            
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
            score -= 300;
            if (score < 0)
            {
                score = 0;
            }
        }

	}

    void LateUpdate()
    {
        if (Time.timeScale != 0)
        {
            xRot += Input.GetAxis("Mouse Y") * lookSensitivity;
            xRot = Mathf.Clamp(xRot, -90, 90);
            cam.transform.localEulerAngles = new Vector3(-xRot, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);
        }
    }


    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpCount < 2)
            {
                rigidbody.AddForce(Vector3.up * 300);
                jumpCount++;
                print("jumping");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Teleporter" && other.GetComponent<Teleporter>().state == true)
        {
            Vector3 teleportPoint = other.transform.GetChild(0).transform.position;
            transform.position = new Vector3(teleportPoint.x, teleportPoint.y, teleportPoint.z);
            
        }

        if (other.tag == "Trampoline" && other.GetComponent<Trampoline>().state == true)
        {
            rigidbody.AddForce(Vector3.up * 500);
            jumpCount = 1;
        }

        if (other.tag == "Key")
        {
            other.gameObject.GetComponent<Renderer>().enabled = false;
            ParticleSystem pe = other.GetComponentInChildren<ParticleSystem>();
            pe.Play();
            Destroy(other.gameObject, 1f);
        }

        if (other.tag == "Goal")
        {
            GameObject[] keyArray = GameObject.FindGameObjectsWithTag("Key");
            if (keyArray.Length == 0)
            {
                if (SceneManager.GetActiveScene().buildIndex > 1)
                {
                    score += 1000;
                }
                continueScene = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 3);
            }
            if (keyArray.Length != 0)
            {
                StartCoroutine(displayKeyAlert());
            }

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
            transform.lossyScale.Set(1, 1, 1);
        }
    }

    void OnCollisionExit(Collision other)
    {
        
        if (other.gameObject.tag == "Moving Platform")
        {
            transform.parent = null;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    IEnumerator displayKeyAlert()
    {
        gameGUI.keyAlertText.enabled = true;
        yield return new WaitForSeconds(3);
        gameGUI.keyAlertText.enabled = false;
    }


}
