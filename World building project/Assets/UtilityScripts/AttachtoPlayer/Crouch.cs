using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    //Attach to your fps controller

    public float crouchHeight=1;
    CharacterController character;
    float characterHeight;
    private bool crouching;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        characterHeight = character.height;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (crouching)
            {
                crouching = false;
            }
            else
            {
                crouching = true;
            }
        }

        if (crouching)
        {
            character.height = crouchHeight;
        }
        else
        {
            character.height = characterHeight;
        }
    }
}
