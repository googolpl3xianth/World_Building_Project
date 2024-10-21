/*
 This script periodically spawns rocks on top the player (or some other object, if desired)
 */

using UnityEngine;
using System.Collections;

public class RockSpawner : MonoBehaviour {

	//The prefab we will be duplicating
	public Transform prefabToSpawn;
	
	//The game object we'll be drop rocks on top of.
	//Find the player in the hierarchy and drag and
	//drop into this variable in the inspector
	public GameObject spawnTarget;
	
	//Time at which to spawn a new prefab
	float timeToSpawn = 0;
	
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//If it's time to spawn a new prefab
		if (timeToSpawn < Time.time)
		{
			//Spawn at the player's position,
			Vector3 spawnPosition = spawnTarget.transform.position;
			//spawnPosition += spawnTarget.rigidbody.velocity * 1f;
			
			//But at this game objects height
			spawnPosition.y = this.transform.position.y;
			//NOTE: This way, you can change what height the rocks fall from
			//by moving the spawner object higher or lower in the scene
			
			//spawn a new rock
			GameObject.Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
			
			//schedule another rock for 2 seconds from the last one
			timeToSpawn += 2;
		}
	}
}
