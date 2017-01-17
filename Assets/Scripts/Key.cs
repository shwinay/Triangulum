using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
    
	void Start ()
    {
	
	}
	
	void Update ()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }
}
