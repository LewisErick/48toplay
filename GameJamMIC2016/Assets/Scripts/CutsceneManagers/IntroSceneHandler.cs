using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroSceneHandler : MonoBehaviour {

	int actionIndex = 0;
	bool boolNeedsToScroll = false;
	bool boolNeedsPress = false;
	int waitCount = 0;
	bool showTitle = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (showTitle && GameObject.Find("Title").GetComponent<SpriteRenderer>().color.a < 1)
		{
			Destroy(GameObject.Find("Ship"));
			GameObject.Find("Title").GetComponent<SpriteRenderer>().color = new Color(
				GameObject.Find("Title").GetComponent<SpriteRenderer>().color.r,
				GameObject.Find("Title").GetComponent<SpriteRenderer>().color.g,
				GameObject.Find("Title").GetComponent<SpriteRenderer>().color.b, 
				GameObject.Find("Title").GetComponent<SpriteRenderer>().color.a + 0.02f);
		}
		else
		{
			if (GameObject.Find("Title").GetComponent<SpriteRenderer>().color.a > 0)
			{
				GameObject.Find("Title").GetComponent<SpriteRenderer>().color = new Color(
				GameObject.Find("Title").GetComponent<SpriteRenderer>().color.r,
				GameObject.Find("Title").GetComponent<SpriteRenderer>().color.g,
				GameObject.Find("Title").GetComponent<SpriteRenderer>().color.b, 
				GameObject.Find("Title").GetComponent<SpriteRenderer>().color.a - 0.02f);	
			}
		}
		if (boolNeedsToScroll)
		{
			if (Input.GetKeyDown(KeyCode.Space) && GameObject.Find("Text").GetComponent<TextBoxHandler>().boolReady)
			{
				boolNeedsToScroll = false;
			}
			else
			{
				return;
			}
		}

		if (boolNeedsPress)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				boolNeedsPress = false;
			}
			else
			{
				return;
			}
		}

		if (waitCount > 0)
		{
			waitCount -= 1;
			return;
		}

		switch (actionIndex)
		{
			case 0:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("P1: Apollo to Houston. Do you copy? Do you copy?");
				boolNeedsToScroll = true;
				break;
			case 1:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("CONTROL: Houston here. Over.");
				boolNeedsToScroll = true;
				break;
			case 2:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("P1: Status report. Mission completed and ready for next assignment.");
				boolNeedsToScroll = true;
				break;
			case 3:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("CONTROL: Copied. Continue your travel to FFFFFF00 for further instructions.");
				boolNeedsToScroll = true;
				break;
			case 4:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("P1: Roger.");
				boolNeedsToScroll = true;
				break;
			case 5:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText(" ");
				GameObject.Find("Textbox").GetComponent<Image>().enabled = false;
				GameObject.Find("AudioMusicTitle").GetComponent<AudioSource>().Stop();
				waitCount = 100;
				break;
			case 6:
				GameObject.Find("Textbox").GetComponent<Image>().enabled = true;
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("CONTROL: P-001, an object of extreme amounts of mas----");
				boolNeedsToScroll = true;
				break;
			case 7:
				GameObject.Find("SoundDirector").GetComponent<SoundDirectorHandler>().SoundStatic();
				GetComponent<AudioSource>().Play();
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("CONTROL: ---------");
				boolNeedsToScroll = true;
				break;
			case 8:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("CONTROL: ---------");
				boolNeedsToScroll = true;
				break;
			case 9:
				GameObject.Find("SoundDirector").GetComponent<SoundDirectorHandler>().Stop();
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("P1: Houston? Over.");
				boolNeedsToScroll = true;
				break;
			case 10:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText(" ");
				GameObject.Find("Textbox").GetComponent<Image>().enabled = false;
				GameObject.Find("BlackHole").GetComponent<BlackHoleCutsceneHandler>().act = true;
				waitCount = 200;
				break;
			case 11:
				showTitle = true;
				waitCount = 400;
				//Show title
				break;
			case 12:
				boolNeedsPress = true;
				break;
			case 13:
				showTitle = false;
				waitCount = 400;
				break;
			case 14:
				GetComponent<AudioSource>().Stop();
				Application.LoadLevel("Level1");
				break;
		}

		actionIndex = actionIndex + 1;
	}
}
