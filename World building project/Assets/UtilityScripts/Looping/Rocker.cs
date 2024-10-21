using UnityEngine;
using System.Collections;

public class Rocker : MonoBehaviour {
	
	Vector3 startEulerAngles;
	Vector3 rotation = new Vector3(0,0, 10);
	float speed = 20;
	
	// Use this for initialization
	void Start () {
		this.startEulerAngles = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.eulerAngles = startEulerAngles + Mathf.Sin(speed*Time.time)*rotation;
	}
}
