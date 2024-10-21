using UnityEngine;
using System.Collections;

public class LegWalker : MonoBehaviour {

	public enum AXIS {X = 0,Y = 1,Z = 2};
	public AXIS axis = AXIS.X;
	public static Vector3[] unitVecs = {new Vector3(1,0,0), new Vector3(0,1,0), new Vector3(0,0,1)};


	float maxSpeed = 10;
	public float minAngle = -45;
	public float maxAngle = 45;

	Vector3 startRotation;
	public float offset = 0;
	public float rate = 1;

	// Use this for initialization
	void Start () {
		startRotation = this.transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 velo = this.transform.root.GetComponent<Rigidbody>().velocity;
		velo.y = 0;
		float speed = rate * velo.magnitude/maxSpeed;

		offset += speed * Time.fixedDeltaTime * 1.5f;
		offset = Mathf.Repeat(offset,1);

		float angCoeff =  (Mathf.Sin(2*offset*Mathf.PI) + 1)/2;

		this.transform.localEulerAngles = this.startRotation + Mathf.Lerp(minAngle, maxAngle, angCoeff) * unitVecs[(int) axis];//new Vector3(,0,0);
	}
	
}
