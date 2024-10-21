using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public float minOnTime = 0.1f;
    public float maxOnTime=2;
    public float minOffTime = 0.1f;
    public float maxOffTime=1;
    Light GetLight;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Light>()) 
        {
            GetLight = GetComponent<Light>();

            StartCoroutine(TurnLightOn(Random.Range(minOffTime, maxOffTime)));

        }
        else
        {
            Debug.LogWarning(this.name + " needs a Light component for the FlickeringLight to function");
        }
    }


    IEnumerator TurnLightOn(float secondsToTurnOn)
    {
        yield return new WaitForSeconds(secondsToTurnOn);
        GetLight.enabled = true;
        StartCoroutine(TurnLightOff(Random.Range(minOnTime, maxOnTime)));
    }

    IEnumerator TurnLightOff(float secondsToTurnOff)
    {
        yield return new WaitForSeconds(secondsToTurnOff);
        GetLight.enabled = false;
        StartCoroutine(TurnLightOn(Random.Range(minOffTime, maxOffTime)));
    }
}
