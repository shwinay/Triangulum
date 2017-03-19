using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroTextScroll : MonoBehaviour {

    public float scrollSpeed = 20;
    Button continueButton;

    void Start()
    {
        continueButton = GameObject.Find("Continue Button").GetComponent<Button>();
        continueButton.image.gameObject.SetActive(false);
        StartCoroutine(makeButtonVisible());
    }
	
	void Update ()
    {
        Vector3 pos = transform.position;

        Vector3 localVectorUp = transform.TransformDirection(0, 1, 0);

        pos += localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;

	}

    IEnumerator makeButtonVisible()
    {
        yield return new WaitForSeconds(27.5f);
        continueButton.enabled = true;
        continueButton.image.gameObject.SetActive(true);
    }
}
