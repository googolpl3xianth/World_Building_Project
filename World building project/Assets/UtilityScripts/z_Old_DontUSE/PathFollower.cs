using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Rigidbody))]

public class PathFollower : MonoBehaviour {



    public List<Transform>  wayPoints = new List<Transform>();
	int targetWayPt = 0;
	public float speed = 2;
	public float waitTime = 2;
	float timeToMove = float.NegativeInfinity;
	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
    }


    // Update is called once per frame
    void FixedUpdate () 
	{

            Vector3 towards = wayPoints[targetWayPt].position - this.transform.position;
            float distance = towards.magnitude;
            towards.Normalize();

            float effSpeed = Mathf.Min(speed * Time.fixedDeltaTime, distance);

            //this.transform.position += towards*effSpeed;
            this.GetComponent<Rigidbody>().MovePosition(this.transform.position + towards * effSpeed);

            if (distance < .1f)
            {
                if (timeToMove == float.NegativeInfinity)
                {
                    timeToMove = Time.time + waitTime;
                }
                else if (Time.time >= timeToMove)
                {
                    targetWayPt = (targetWayPt + 1) % wayPoints.Count;
                    timeToMove = float.NegativeInfinity;
                }
            
        }
	}
}
