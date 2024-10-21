using UnityEngine;
using System.Collections;

public class RestartLevelOnFall : MonoBehaviour {

	int level;
	public GameObject player;

	// Use this for initialization
	void Start () {
		level = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.transform.position.y < this.transform.position.y)
		{
			Application.LoadLevel(level);
		}
	}
}
