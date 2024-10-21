using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class TriggerSound : MonoBehaviour
{
   
    AudioSource audioSource;

    private void Update()
    {
        if (GetComponent<AudioSource>() == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        if (Application.isPlaying)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //if(!audioSource.isPlaying)
        audioSource.Play();
    }
}
