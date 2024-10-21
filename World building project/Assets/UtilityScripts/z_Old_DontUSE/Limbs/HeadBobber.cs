using UnityEngine;
using System.Collections;

public class HeadBobber : MonoBehaviour {


	float maxSpeed = 10;

	public Vector3 displacement = new Vector3(0,3,0);

	Vector3 startPosition;
	public float offset = 0;
	public float rate = 1;

	// Use this for initialization
	void Start () {
		startPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 velo = this.transform.root.GetComponent<Rigidbody>().velocity;
		velo.y = 0;
		float speed = rate * velo.magnitude/maxSpeed;

		offset += speed * Time.fixedDeltaTime * 1.5f;
		offset = Mathf.Repeat(offset,1);

		this.transform.localPosition = this.startPosition + Mathf.Sin(2*offset*Mathf.PI) *.1f * displacement;
	}
	
}
