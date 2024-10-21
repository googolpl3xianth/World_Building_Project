/*
This script will destroy its game object after a specified number of seconds
 */

using UnityEngine;
using System.Collections;

public class DestroyOnTimer : MonoBehaviour {
	
	// How long the object will live
	public float lifespan = 5;
	
	//The time at which the object was created
	float birthTime;
	
	void Start () {
		
		//record the time the object
		birthTime = Time.time;
	}
	
	
	void Update () 
	{
		//if it is 'lifespan' number of seconds after the object's birth time
		if (Time.time > birthTime + lifespan)
		{
			//Destroy the entire game object, and all components.
			Destroy(this.gameObject);	
		}
	}
}
