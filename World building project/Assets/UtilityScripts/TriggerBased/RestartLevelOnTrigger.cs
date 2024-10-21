using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelOnTrigger : MonoBehaviour
{
    int level;
    Collider player;

    // Use this for initialization
    void Start()
    {
        level = Application.loadedLevel;
        player = FindObjectOfType<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other==player)
        Application.LoadLevel(level);
    }
}
