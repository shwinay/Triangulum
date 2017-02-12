using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{

    public Text timerText;
    public Text ammoText;
    public Text scoreText;
    public float startTime;
    private float delayTime;

    Raycast rc;

	void Start ()
    {
        delayTime = 3f;
        startTime = Time.timeSinceLevelLoad + startTime;
        rc = GameObject.FindGameObjectWithTag("Gun").GetComponent<Raycast>();
	}
	
	void Update ()
    {
        if (delayTime - Time.timeSinceLevelLoad <= 0)
        {
            float t = startTime + delayTime - Time.timeSinceLevelLoad;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");

            if (t >= 0)
            {
                timerText.text = minutes + ":" + seconds;
            }
            
            else
            {
                timerText.text = "0:0";
                //Go to died menu

            }

            if (t <= 10)
            {
                timerText.color = Color.red;
            }

        }

        ammoText.text = "Ammo: " + rc.ammo.ToString();
        scoreText.text = "Score: " + PlayerController.score.ToString();

	}
}
