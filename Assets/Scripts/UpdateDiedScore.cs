using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateDiedScore : MonoBehaviour {

    public Text scoreText;

	void Update ()
    {
        scoreText.text = "Score: " + PlayerController.score.ToString();
	}
	
}
