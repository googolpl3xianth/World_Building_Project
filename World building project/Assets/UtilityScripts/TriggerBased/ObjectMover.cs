using UnityEngine;
using System.Collections;
using System.Reflection;

public class ObjectMover : MonoBehaviour {

	public bool useRelative;
	public bool useForce;

	//should be approximately the scale of the object
	//leave at -1 and it will automatically determine from mesh
	public float speedScaling = -1;

	void Start () {
		if(GetComponent<Rigidbody>() == null)
			gameObject.AddComponent<Rigidbody>();
		if(speedScaling == -1)
			speedScaling = GetComponent<MeshFilter>().mesh.bounds.max.magnitude;

	}



	public int rotation = 0;
	public int movement = 0;

	void Update () {

		//if we're not using force then we don't want the rigid body to do its collision thing
		GetComponent<Rigidbody>().isKinematic = !useForce;

		if(Input.GetKey(KeyCode.UpArrow)) movement = 1;
		else if(Input.GetKey(KeyCode.DownArrow)) movement = -1;
		else movement = 0;

		if(Input.GetKey(KeyCode.LeftArrow)) rotation = -1;
		else if(Input.GetKey(KeyCode.RightArrow)) rotation = 1;
		else rotation = 0;

		//bad use of reflection but hey saves me 4 if statements ;)
		this.SendMessage((useForce ? "force" : "move") + "_" + (useRelative ? "relative" : "absolute"));
	}

	void force_relative()
	{
		GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*movement*speedScaling*10);
		GetComponent<Rigidbody>().AddRelativeTorque(Vector3.up*rotation*speedScaling*2);
	}

	void force_absolute()
	{
		GetComponent<Rigidbody>().AddForce(Vector3.forward*movement*speedScaling*10);
		//rigidbody.AddForce(Vector3.right*rotation*speedScaling*10);
		//alternative version that does rotation
		GetComponent<Rigidbody>().AddTorque(Vector3.up*rotation*speedScaling*1);
	}

	void move_relative()
	{
		//we use transform.forward/up because we want the rotation relative to the object
		transform.position += transform.forward*movement*speedScaling*Time.deltaTime;
		transform.rotation *= Quaternion.AngleAxis(rotation*speedScaling*Time.deltaTime*80,transform.up);
	}

	void move_absolute()
	{
		transform.position += Vector3.forward*movement*speedScaling*Time.deltaTime;
		transform.position += Vector3.right*rotation*speedScaling*Time.deltaTime;
		//alternative version that does rotation
		//transform.rotation *= Quaternion.AngleAxis(rotation*speedScaling*Time.deltaTime*40,Vector3.up);
	}
}
