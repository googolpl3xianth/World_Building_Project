using UnityEngine;
using System.Collections;

public class OnCollideExplode : MonoBehaviour 
{
	
	// A grenade
	// - instantiates a explosion prefab when hitting a surface
	// - then destroys itself
	public GameObject explosionPrefab;
	public float      explodeSecs = -1;
	
	void Awake()
	{
		if(explodeSecs > -1) Invoke ("DestroyNow", explodeSecs);
	}
	
	void OnCollisionEnter( Collision collision ) 
	{
		// Rotate the object so that the y-axis faces along the normal of the surface
		ContactPoint contact = collision.contacts[0];
		Quaternion   rot     = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3      pos     = contact.point;
		Instantiate(explosionPrefab, pos, rot);
		// Destroy the projectile
		Destroy (gameObject);
	}
	
	void DestroyNow()
	{
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}
	
	
	
	
}