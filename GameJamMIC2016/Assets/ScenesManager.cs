using UnityEngine;
using System.Collections;

public class ScenesManager : MonoBehaviour {




	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Application.LoadLevel(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Application.LoadLevel(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Application.LoadLevel(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Application.LoadLevel(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Application.LoadLevel(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Application.LoadLevel(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Application.LoadLevel(6);
        }
	
	}
}
