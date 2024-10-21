using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class Launch : MonoBehaviour {

	public float launchSpeed = 25;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody>().velocity = this.transform.forward * launchSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
