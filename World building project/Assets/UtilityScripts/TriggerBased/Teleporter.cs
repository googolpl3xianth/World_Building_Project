using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    public Transform teleportTo;

    

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<CharacterController>())
        {
            col.GetComponent<CharacterController>().enabled = false;
            col.gameObject.transform.position = teleportTo.position;
            col.GetComponent<CharacterController>().enabled = true;
        }
        else
        {
            col.gameObject.transform.position = teleportTo.position;
        }

    }


}
