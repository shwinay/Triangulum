using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateDiedScore : MonoBehaviour {

    public Text scoreText;

	void Start ()
    {
        //if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings)
        //{
        //    scoreText.text = "Your Score: " + PlayerController.score.ToString();
        //}

        scoreText.text = "Score: " + PlayerController.score.ToString();
	}
	
}
