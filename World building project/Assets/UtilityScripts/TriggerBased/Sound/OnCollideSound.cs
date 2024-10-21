using UnityEngine;

public class OnCollideSound : MonoBehaviour 
{
	public AudioClip collisionSound;
	public float      triggerMagnitude = 2;
	
	void OnCollisionEnter( Collision collision ) 
	{
		if (collision.relativeVelocity.magnitude > triggerMagnitude)
		{
			AudioSource.PlayClipAtPoint(collisionSound, this.transform.position);
		}	
	}
}