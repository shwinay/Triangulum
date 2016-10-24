using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

    RaycastHit hit;

    Vector3 endPoint;
    float dist = 10f;
    ParticleSystem tracer;

	void Start ()
    {
	}
	
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            checkRaycast();
        }

	}

    public bool checkRaycast()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f))
        {
            dist = Vector3.Distance(transform.position, hit.point);
            print(hit.transform.name);
            return true;
        }
        else
        {
            dist = 10;
            return false;
        }

    }

}
