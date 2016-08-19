using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndingSceneHandler : MonoBehaviour {

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
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("And so, P-001 was able to escape from his ship safely.");
				boolNeedsToScroll = true;
				break;
			case 1:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("Conveniently, P-001's outfit had a built-in escape pod.");
				boolNeedsToScroll = true;
				break;
			case 2:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("And so, P-001 roams now the galaxy,");
				boolNeedsToScroll = true;
				break;
			case 3:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText("until he can find a new way home.");
				boolNeedsToScroll = true;
				break;
			case 5:
				GameObject.Find("Text").GetComponent<TextBoxHandler>().showText(" ");
				GameObject.Find("Textbox").GetComponent<Image>().enabled = false;
				break;
		}

		actionIndex = actionIndex + 1;
	}
}
