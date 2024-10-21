using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//HOW TO USE: place this on an object with a collider, and put a sprite on it.
//If the player clicks on the collider, the sprite under imageToShow will appear on the screen
//good to use for documents and other things you want the player to look at.
[ExecuteAlways]
public class ExamineObjectScript : MonoBehaviour
{
    public Sprite imageToShowOnClick;
    public float imageSizeWhenShown=1;
    public float selectedSize = 1.5f;
    [Tooltip("Leave at white for no change")]
    public Color selectedColor = Color.green;
    public AudioClip soundToPlayOnClick;
    bool showExamineDetail;
    internal bool HasBeenExamined;
    Canvas canvas;
    Image image;
    Vector3 size;
    AudioSource audioSource;
    Renderer[] renderers;
    List<List<Color>> originalColors;
    public GameObject DeactivateOnClick;
    public GameObject ActivateOnClick;
    private bool IsMouseOverObject;

    void OnMouseDown()
    {
        //Debug.Log("Clicked on the object this script is attached to");
        //show the paper
        showExamineDetail = true;

        if (DeactivateOnClick != null)
        {
            DeactivateOnClick.SetActive(false);
        }

        if (ActivateOnClick != null)
        {
            ActivateOnClick.SetActive(true);
        }

        if (soundToPlayOnClick != null)
        {
            audioSource.time = 0;
            audioSource.Play();
        }

    }

    private void OnMouseEnter()
    {
        transform.localScale=size*selectedSize;


        for (int i = 0; i < renderers.Length; i++)
        {
            for (int j = 0; j < renderers[i].materials.Length; j++)
            {
                renderers[i].materials[j].color = Color.Lerp(renderers[i].materials[j].color,selectedColor,selectedColor.a);
            }
        }
       
}

    private void OnMouseOver()
    {
        IsMouseOverObject = true;
    }


    private void OnMouseExit()
    {
        transform.localScale = size;

        for (int i = 0; i < renderers.Length; i++)
        {
            for (int j = 0; j < renderers[i].materials.Length; j++)
            {
                renderers[i].materials[j].color = originalColors[i][j];
            }
        }

        IsMouseOverObject = false;
    }

    void Start()
    {
        if (Application.isPlaying)
        {
            audioSource = GetComponent<AudioSource>();
            renderers = GetComponentsInChildren<Renderer>();

            originalColors = new List<List<Color>>();
            foreach (var ren in renderers)
            {
                List<Color> colors = new List<Color>();
                foreach(var mat in ren.materials)
                {
                    colors.Add(mat.color);
                }

                originalColors.Add(colors);
            }



            GameObject go = GameObject.Find("ExamineObjectCanvas");

            if (go != null)
            {
                canvas = go.GetComponent<Canvas>();
            }
            else
            {
                canvas = new GameObject("ExamineObjectCanvas", typeof(Canvas)).GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.worldCamera = FindObjectOfType<Camera>();
            }

            if (soundToPlayOnClick != null)
            {
               audioSource.clip = soundToPlayOnClick;
            }


                image = new GameObject("examineImage", typeof(Image)).GetComponent<Image>();
            image.transform.SetParent(canvas.transform);
            image.transform.localPosition = Vector3.zero;
            if (imageToShowOnClick != null)
            {
                image.sprite = imageToShowOnClick;
            }
            else 
            {
                image.sprite = null;
                image.color = new Color(0, 0, 0, 0);
            }
       
            image.SetNativeSize();
            image.transform.localScale = Vector3.one * imageSizeWhenShown;
            image.gameObject.SetActive(false);


            size = transform.localScale;
            
        }
        else
        {
            if (!gameObject?.GetComponent<AudioSource>())
            {
                Debug.LogWarning(
                 gameObject.name + " needs and audiosource, audiosource added");
                audioSource = gameObject.AddComponent<AudioSource>();
            }
     
        }

    }

    private void Update()
    {
        if (Application.isPlaying)
        {
            if (showExamineDetail)
            {
                image.gameObject.SetActive(true);
            }

            if (showExamineDetail && !IsMouseOverObject)
            {
                if (!HasBeenExamined)
                    HasBeenExamined = true;

                showExamineDetail = false;
                image.gameObject.SetActive(false);
            }
        }
     }

    bool HasMouseMoved()
    {
        return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
    }

    private void OnDestroy()
    {
        if (Application.isPlaying)
        {
            if(image!=null)
            image?.gameObject.SetActive(false);
        }
    }
}
