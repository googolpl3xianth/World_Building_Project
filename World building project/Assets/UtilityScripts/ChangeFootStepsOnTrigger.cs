using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFootStepsOnTrigger : MonoBehaviour
{
    public AudioClip[] newFootSteps;
    public AudioClip newLandSound;

    AudioClip[] defaultFootsteps;
    AudioClip defaultLandSound;


    private void Start()
    {
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

        defaultFootsteps = firstPersonController.m_FootstepSounds;
        defaultLandSound = firstPersonController.m_LandSound;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>()!=null)
        {
            UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController =
            other.transform.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
                
            firstPersonController.m_FootstepSounds = newFootSteps;

            if(newLandSound)
                firstPersonController.m_LandSound = newLandSound;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>() != null)
        {
            UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController =
            other.transform.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

            firstPersonController.m_FootstepSounds = defaultFootsteps;
            firstPersonController.m_LandSound = defaultLandSound;
        }
    }
}
