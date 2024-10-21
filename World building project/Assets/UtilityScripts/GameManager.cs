using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//Set Cursor to not be visible
		Cursor.visible = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		//Restart on Escape
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();

		
	}
}
