/*
 TimedSpawner periodically duplicates a prefab and places it randomly in the scene.
*/

using UnityEngine;
using System.Collections;

public class TimedSpawner : MonoBehaviour {
	
	
	// The prefab we will duplicate, and place in the scene
	public Transform prefabToSpawn;
    public float spawnrate;
	
	//The time at we should spawn a new prefab
	float timeToSpawn;
	
	//NOTE: Time is measured in number of seconds since the start of the game.
	//http://docs.unity3d.com/Documentation/ScriptReference/Time.html
	
	//Start is called once, at the birth of the object
	void Start () 
	{
		//Set the next spawn time to be right now.
		timeToSpawn = Time.time;
		
		
	}
	
	// Update is called continuously, once per frame
	void Update () {
		
		//If we are at, or past the time at which we are scheduled
		//to spawn a prefab...
		if (timeToSpawn <= Time.time)
		{
			
			
			//The spawn position  will be relative to the position of the spawner game object
			//(The empty game object to which you attached this script)
			Vector3 spawnPosition = this.transform.position;
			
			
			//Move the spawn point randomly in the 'X' and 'Z' dimensions,
			//within a fixed range.
			
			float maxSpawnDistance = .5f;
			spawnPosition.x += Random.Range(-maxSpawnDistance, maxSpawnDistance);
			spawnPosition.z += Random.Range(-maxSpawnDistance, maxSpawnDistance);
			
			//NOTE: We do not move it randomly in the y direction,  else it might be
			//spawned to high for the player to reach.
			
			
			//Spawn the prefab at this randomized position
			GameObject.Instantiate(prefabToSpawn, spawnPosition, transform.rotation);
			
			//NOTE: The last argument, (here 'Quaternion.identity') is used to specify
			//the rotation of the newly spawned game object.  'Quaternion.identity' is 
			//simply specifying that we want the object to be unrotated from its default.
			
			//schedule the next spawn time to be 2 seconds from now
			timeToSpawn = Time.time + spawnrate;
		}
	}
}
