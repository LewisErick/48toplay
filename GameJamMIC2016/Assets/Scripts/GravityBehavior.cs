using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GravityBehavior : MonoBehaviour {
	public List<GameObject> movableObjects;
	public Object[] sceneObjects;

	// Use this for initialization
	void Start ()
	{
		sceneObjects = GameObject.FindObjectsOfType(typeof (GameObject));
		movableObjects =  new List<GameObject>();

		foreach(GameObject obj in sceneObjects)
		{
			if(obj.GetComponent<MovableComponent>() != null)
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
			foreach (GameObject obj in movableObjects)
			{
				obj.GetComponent<MovableComponent>().applyGravity();
			}
	}
}
}