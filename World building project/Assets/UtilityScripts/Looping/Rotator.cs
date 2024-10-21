using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	
	public float speed = 200;
	public Vector3 rotation = new Vector3(0,5,0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		this.transform.localEulerAngles = this.transform.localEulerAngles + .1f * speed * Time.fixedDeltaTime * rotation;
	
	}
}
