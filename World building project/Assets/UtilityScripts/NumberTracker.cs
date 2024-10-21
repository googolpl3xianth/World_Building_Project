using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class NumberTracker : MonoBehaviour
{
    public List<GameObject> ThingsToTrack;
    public string trackerText;
    public Canvas canvas;
    public TMP_Text text;
    int initialThingCount;


    private void Start()
    {
        //canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.worldCamera = FindObjectOfType<Camera>();
        initialThingCount = ThingsToTrack.Count;
    }

    private void Update()
    {
        ThingsToTrack = ThingsToTrack.Where(item => item != null).ToList();

        int thingCount = initialThingCount-ThingsToTrack.Count;

        text.text = string.Format("{0}/{1} {2}", thingCount, initialThingCount, trackerText);
    }


}
