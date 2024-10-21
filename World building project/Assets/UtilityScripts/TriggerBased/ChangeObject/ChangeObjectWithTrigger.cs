using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectWithTrigger : MonoBehaviour
{
    public bool triggerOnce;
    public GameObject ObjectActiveWhenInsideTrigger;
    public GameObject ObjectActiveWhenOutsideTrigger;
    bool triggered;

    private void OnTriggerEnter(Collider other)
    {

            if (!triggered)
            {
                if (ObjectActiveWhenInsideTrigger != null)
                    ObjectActiveWhenInsideTrigger.SetActive(true);

                if (ObjectActiveWhenOutsideTrigger != null)
                    ObjectActiveWhenOutsideTrigger.SetActive(false);

                if(triggerOnce)
                triggered = true;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!triggered)
        {
            if (ObjectActiveWhenInsideTrigger != null)
                ObjectActiveWhenInsideTrigger.SetActive(false);
            if (ObjectActiveWhenOutsideTrigger != null)
                ObjectActiveWhenOutsideTrigger.SetActive(true);
        }
    }
}
