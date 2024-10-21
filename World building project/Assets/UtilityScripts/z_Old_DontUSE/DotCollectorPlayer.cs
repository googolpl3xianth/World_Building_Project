/* 
This script 
+ maintains game state, like life, score, etc...
+ handles player related events, like taking damage, or collecting a dot.
+ Draws the HUD on the screen (number of lives, points, game over message...)
  */

using UnityEngine;
using System.Collections;


public class DotCollectorPlayer : MonoBehaviour {
	
	//References to the sounds played when you collect a dot,
	//and get hurt by a falling block
	//Find them in Assets/SOUNDS and then drop them
	//into the inspector.
	public AudioClip collectSound;
	public AudioClip hurtSound;
	
	//References to the fonts used for the HUD
	//Find them in them in Assets/MISC and drop them into 
	//the inspector
	public Font hudFont;
	public Font messageFont;
	
	//Number of hits the player can take before dying
	int life = 3;
	
	//The number of dots the player has collected
	int score = 0;
	
	void Start () 
	{
	}
	
	void Update () 
	{	
	}
	
	//Increment the score when we collide with a dot.
	void OnTriggerEnter(Collider other) 
	{
		score += 1;
		AudioSource.PlayClipAtPoint(this.collectSound, this.transform.position);
    }
	//NOTE: The player will gain a point if they hit ANY trigger
	//object.  We're being a bit lazy here, but it's ok since we know
	//the only triggers are the dots.
	
	//Allow other objects to tell the player when to take damage.
	public void takeDamage()
	{
		//Decrease life
		life = life - 1;
		
		//Play the hurt sound
		AudioSource.PlayClipAtPoint(hurtSound, this.transform.position);
		
		//If you've run out of lifes
		if (life <= 0)
		{
			//Disable the player's collider.
			//They will fall through the ground and disappear
			this.GetComponent<Collider>().enabled = false;
		}
	}
	
	//In this function you can draw text, buttons, images and other things
	//More information here:
	//http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.OnGUI.html
	void OnGUI() 
	{
		//Create a new style, and set the font.
		GUIStyle myStyle = new GUIStyle();
    	myStyle.font = hudFont;
		
		//Display 1 ascii heart (<3) for each life
		string healthString = "HP:";
		for (int i = 0; i < this.life; i++)
		{
			healthString = healthString + " <3";
		}
		
		//Display the number of lives
        GUI.Label(new Rect(10, 10, 100, 20), healthString, myStyle);
	
		//Display the score
		GUI.Label(new Rect(10, 30, 100, 20), "SCORE: " + score, myStyle);
		
		//If the player is dead....
		if (this.life <= 0)
		{
			//Also draw the game over text
			
			//Set the font
			myStyle.font = messageFont;
			
			//Calculate the size of the text in pixels, (so we can center it on the screen)
			Vector2 txtSize = myStyle.CalcSize(new GUIContent("GAME OVER"));
			
			//Draw "GAME OVER" in the center of the screen
			GUI.Label(new Rect(Screen.width/2 - txtSize.x/2, Screen.height/2 - txtSize.y/2, txtSize.x, txtSize.y), "GAME OVER", myStyle);
		}
		
	}

	
}
