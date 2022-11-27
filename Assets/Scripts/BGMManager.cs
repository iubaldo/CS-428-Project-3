using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// basically just trackManagerLite
public class BGMManager : MonoBehaviour
{
    bool canSwitch = true;

    //Grab the Audio from the record player.
    public AudioSource audioSource;
    public AudioClip track1;
    public AudioClip track2;


    public void Switchtracks(int targetTrack)
    {
        if (canSwitch) // don't allow user to switch tracks during a switch
        {
            canSwitch = false;
            StartCoroutine(FadeOut(targetTrack));
        }
    }


    IEnumerator FadeOut(int track)
    {
        float waitTime = 5f;
        float startTime = Time.time;
        float endTime = startTime + waitTime;


        while (Time.time < endTime)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0, (Time.time - startTime) / waitTime);
        }

        StartCoroutine(FadeIn(track)); // when done, fade in the next
        yield return null;
    }


    IEnumerator FadeIn(int track)
    {
        float waitTime = 5f;
        float startTime = Time.time;
        float endTime = startTime + waitTime;

        switch (track)
        {
            case 0: audioSource.clip = track1; break;
            case 1: audioSource.clip = track2; break;
        }
        audioSource.Play();

        while (Time.time < endTime)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 1, (Time.time - startTime) / waitTime);
        }

        canSwitch = true;
        yield return null;
    }
}
