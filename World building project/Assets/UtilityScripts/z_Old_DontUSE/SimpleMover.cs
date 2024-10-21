using UnityEngine;
using System.Collections;

//Adds a rigidbody if you don't have one
[RequireComponent (typeof (Rigidbody))]

public class SimpleMover : MonoBehaviour {
	
	public KeyCode upKey = KeyCode.UpArrow;
	public KeyCode downKey = KeyCode.DownArrow;
	public KeyCode leftKey = KeyCode.LeftArrow;
	public KeyCode rightKey = KeyCode.RightArrow;
	
	public float movementSpeed = 10;
	bool jumpOk = false;

	Bounds wholeBounds; //used to get rought length, width and height of player

	// Use this for initialization
	void Start () {

		//Calculate the dimensions of the object, so when we check the distance to the ground
		//from the center point of the player, we can tell if we're actually standing on the 
		//ground (distanceToGround <= half player height) or still in midair (distanceToGround > half player height)
		wholeBounds = new Bounds();
		if(this.GetComponent<Collider>() != null)
		{
			wholeBounds.Encapsulate(this.GetComponent<Collider>().bounds);
		}

		print ("count " +  GetComponentsInChildren<Collider>().Length);

		foreach(Collider col in GetComponentsInChildren<Collider>())
		{
			wholeBounds.Encapsulate(col.bounds);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 moveDirection = new Vector3(0, 0, 0);
		if (Input.GetKey(upKey))
		{
			moveDirection += new Vector3(0,0,movementSpeed);
		} 
		
		if (Input.GetKey(downKey))
		{
			moveDirection += new Vector3(0,0,-movementSpeed);
		}
		
		if (Input.GetKey(leftKey))
		{
			moveDirection += new Vector3(-movementSpeed,0,0);
		} 
		
		if (Input.GetKey(rightKey))
		{
			moveDirection += new Vector3(movementSpeed,0,0);
		}
		

		moveDirection.y = GetComponent<Rigidbody>().velocity.y; //preserve gravity
		
		//this.rigidbody.velocity = moveDirection;
	
		GetComponent<Rigidbody>().velocity = moveDirection;

		//this.rigidbody.AddForce(moveDirection * .1f, ForceMode.VelocityChange);

		if (Input.GetKeyDown(KeyCode.Space) )
		{
			float distToGround = wholeBounds.size.y/2;

			jumpOk =  Physics.Raycast(transform.position, -Vector3.up, distToGround + .01f) && this.GetComponent<Rigidbody>().velocity.y <= 0;

			if (jumpOk)
			{
				this.GetComponent<Rigidbody>().velocity += new Vector3(0, 13, 0);  //AddForce(new Vector3(0, 10, 0), ForceMode.VelocityChange);
				jumpOk =false;
			} 
		}

	}
	
	



}
