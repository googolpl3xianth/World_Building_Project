using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CollectibleManager : MonoBehaviour {

	List<GameObject> collectibles;
    List<ExamineObjectScript> examineObjects;



	bool dontSwitchScene = false;

	public GameObject objectToEnableOnWin;
	public bool restartLevelOnWin = false;
    public bool ExamineObjectsAreCollectible=false;

	// Use this for initialization
	void Start () {

		if (objectToEnableOnWin != null)
			objectToEnableOnWin.SetActive (false);

		collectibles =  new List<GameObject>();
        examineObjects = new List<ExamineObjectScript>();


        object[] allObjects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) ;


		foreach(object thisObject in allObjects)
		{
			if (((GameObject) thisObject).activeInHierarchy && ((GameObject) thisObject).GetComponent<Collectible>() != null)
			{
				collectibles.Add((GameObject) thisObject);
			}

            if (ExamineObjectsAreCollectible)
            {
                if (((GameObject)thisObject).activeInHierarchy && ((GameObject)thisObject).GetComponent<ExamineObjectScript>() != null)
                {
                    examineObjects.Add(((GameObject)thisObject).GetComponent<ExamineObjectScript>());
                }
            }
        }

		dontSwitchScene = collectibles.Count == 0;
	}

	// Update is called once per frame
	void Update () 
	{
        //fix this!TODO can only get examine objects if there is one or more  collectible in the scene
		int nonNullCollectibles = 0;
		foreach(GameObject go in this.collectibles)
		{
			if (go != null)
			{
				nonNullCollectibles++;
			}
		}

        foreach (ExamineObjectScript examineObject in examineObjects)
        {
            if (!examineObject.HasBeenExamined)
            {
                nonNullCollectibles++;
            }
        }


        if (nonNullCollectibles == 0 && !dontSwitchScene)
		{
			if (objectToEnableOnWin != null)
				objectToEnableOnWin.SetActive (true);

			if (restartLevelOnWin)
				Invoke ("Restart", 5);

			dontSwitchScene = true;
		}
	}

	public void Restart() {
        SceneManager.LoadScene(0);
	}

}

