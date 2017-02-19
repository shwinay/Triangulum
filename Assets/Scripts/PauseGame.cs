using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    public Canvas pauseCanvas;

	void Start ()
    {
        pauseCanvas.enabled = false;
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseCanvas.enabled)
            {
                pauseGame();
            }

            else if (pauseCanvas.enabled)
            {
                unpauseGame();
            }

        }
	}

    public void unpauseGame()
    {
        pauseCanvas.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void pauseGame()
    {
        pauseCanvas.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

}
