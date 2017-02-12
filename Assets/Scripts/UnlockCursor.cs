using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UnlockCursor : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
}
