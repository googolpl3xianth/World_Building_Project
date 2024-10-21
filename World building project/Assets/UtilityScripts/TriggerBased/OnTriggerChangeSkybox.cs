using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerChangeSkybox : MonoBehaviour
{
    public Material SkyboxToChangeTo;


    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.skybox = SkyboxToChangeTo;
    }
}
