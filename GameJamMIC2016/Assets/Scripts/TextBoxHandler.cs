using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxHandler : MonoBehaviour {

	int charIndex = 0;
	int textSpeed = 2;
	int textCount = 0;

	string stringToShow = "";
	string stringSoFar = "";

	public bool boolReady = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (stringToShow != "")
		{
			if (
				textCount > 0
				)
			{
				textCount -= 1;

				if (Input.GetKeyDown(KeyCode.Space))
				{
					stringSoFar = stringToShow;
					charIndex = stringToShow.Length;
					boolReady = true;
					textCount = 0;
				}
			}
			else
			{
				if (Input.GetKeyDown(KeyCode.Space) && charIndex > 0)
				{
					stringSoFar = stringToShow;
					charIndex = stringToShow.Length;
					boolReady = true;
					textCount = 0;
				}

				if (charIndex < stringToShow.Length)
				{
					stringSoFar = stringSoFar + stringToShow[charIndex];
					textCount = textSpeed;
					charIndex = charIndex + 1;
				}
				else
				{
					GetComponent<AudioSource>().Stop();
					boolReady = true;
				}
			}

			GetComponent<Text>().text = stringSoFar;
		}
	}

	public void showText(
		string text
		)
	{
		stringToShow = text;
		textCount = 0;
		stringSoFar = "";
		charIndex = 0;
		boolReady = false;
		GetComponent<AudioSource>().Play();
		GetComponent<AudioSource>().loop = true;
	}
}
