using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceSound : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource violin;
    public float speed;
    public float waitDuration;
    public float bgmMaxVolume = 1.5f;
    public float violinVolume = 5f;

    private void OnTriggerEnter(Collider other)
    {
        StopAllCoroutines();
        StartCoroutine(TurnDownSound(backgroundMusic));
        violin.Play();
        StartCoroutine(TurnUpSound(violin, violinVolume));
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
        StartCoroutine(TurnUpSound(backgroundMusic, bgmMaxVolume));
        StartCoroutine(TurnDownSound(violin));
        
    }

    IEnumerator TurnDownSound(AudioSource music)
    {
        while (music.volume > 0)
        {
            music.volume -= speed;
            yield return new WaitForSeconds(waitDuration);
        }

        
    }

    IEnumerator TurnUpSound(AudioSource music, float maxVolume)
    {
        while (music.volume < maxVolume)
        {
            music.volume += speed;
            yield return new WaitForSeconds(waitDuration);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
