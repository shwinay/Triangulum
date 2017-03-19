using UnityEngine;
using System.Collections;

public class MenuAnimation : MonoBehaviour
{

    public Transform currentMount;
    float speedFactor;

	void Start ()
    {
        speedFactor = 0.05f;
	}
	

	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, currentMount.position, speedFactor);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speedFactor);
	}
}
