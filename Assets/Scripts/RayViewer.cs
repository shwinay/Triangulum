using UnityEngine;
using System.Collections;

public class RayViewer : MonoBehaviour {

    public float remoteRange = 10f;

    Camera cam;

	void Start ()
    {
        cam = Camera.main;
	}
	
	void Update ()
    {
        Vector3 lineOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(lineOrigin, cam.transform.forward * remoteRange, Color.green);
	}
}
