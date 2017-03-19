using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateDiedScore : MonoBehaviour {

    public Text scoreText;

	void Update ()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            scoreText.text = "Your Score: " + PlayerController.score.ToString();
        }

        scoreText.text = "Score: " + PlayerController.score.ToString();
	}
	
}
