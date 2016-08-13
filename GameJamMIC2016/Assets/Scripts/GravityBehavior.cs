using UnityEngine;
using System.Collections;

public class GravityBehavior : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		GameObject[] sceneObjects = GameObject.FindObjectsOfType(typeof (GameObject));
		List<GameObject> movableObjects =  new List<GameObject>;

		foreach(object obj in sceneObjects)
		{
			if(obj.GetComponen<MovableComponent> != null)
			{

				movableObjects.Add(obj);
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown("space"))
		{
			foreach (object obj in movableObjects)
			{
				obj.GetComponen<MovableComponent>.applyGravity();
			}
	}
}
