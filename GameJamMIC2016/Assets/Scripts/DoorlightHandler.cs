using UnityEngine;
using System.Collections;

public class DoorlightHandler : MonoBehaviour {

	public bool boolClear;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void UpdateDoorlight () {
		boolClear = true;
		GameObject[] arrgamobj = GameObject.FindGameObjectsWithTag("Button");

		foreach (GameObject gamobj in arrgamobj)
		{
			if (gamobj.GetComponent<ButtonBehavior>() != null &&
				gamobj.GetComponent<ButtonBehavior>().boolOn == false)
			{
				boolClear = false;
				break;
			}

			if (gamobj.GetComponent<ButtonBehavior2>() != null &&
				gamobj.GetComponent<ButtonBehavior2>().boolOn == false)
			{
				boolClear = false;
				break;
			}
		}

		if (boolClear)
		{
			GetComponent<Light>().color = new Color(0, 240, 0, 1f);
		}
		else
		{
			GetComponent<Light>().color = new Color(240, 0, 0, 1f);	
		}
	}
}
