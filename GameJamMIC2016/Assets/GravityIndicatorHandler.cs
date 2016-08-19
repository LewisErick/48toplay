using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GravityIndicatorHandler : MonoBehaviour {

	public Sprite bar1up;
	public Sprite bar2up;
	public Sprite bar3up;

	public Sprite bar1down;
	public Sprite bar2down;
	public Sprite bar3down;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int intGravityState = GameObject.Find("Player").GetComponent<PlayerMovement>().intGravityState;
		bool boolGravityInverted = GameObject.Find("Player").GetComponent<PlayerMovement>().boolGravityInverted;

		if (boolGravityInverted)
		{
			switch (intGravityState)
			{
				case 0:
					GetComponent<Image>().sprite = bar1up;
					break;
				case 1:
					GetComponent<Image>().sprite = bar2up;
					break;
				case 2:
					GetComponent<Image>().sprite = bar3up;
					break;
			}
		}
		else
		{
			switch (intGravityState)
			{
				case 0:
					GetComponent<Image>().sprite = bar1down;
					break;
				case 1:
					GetComponent<Image>().sprite = bar2down;
					break;
				case 2:
					GetComponent<Image>().sprite = bar3down;
					break;
			}
		}
	}
}
