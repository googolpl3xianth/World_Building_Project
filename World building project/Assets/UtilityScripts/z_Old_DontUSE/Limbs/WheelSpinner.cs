using UnityEngine;
using System.Collections;

public class WheelSpinner : MonoBehaviour {

	float maxSpeed = 10;
	public float rate = 1;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 velo = this.transform.root.GetComponent<Rigidbody>().velocity;
		velo.y = 0;
		float speed = rate * velo.magnitude/maxSpeed;
		this.transform.Rotate(new Vector3(Time.fixedDeltaTime * 500 * speed, 0, 0));//.localEulerAngles += new Vector3(Time.deltaTime * 100 * speed, 0, 0);

	}
}
