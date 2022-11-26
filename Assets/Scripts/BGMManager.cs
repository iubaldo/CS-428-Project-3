using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// basically just FloorManagerLite
public class BGMManager : MonoBehaviour
{
    bool canSwitch = true;

    //Grab the Audio from the record player.
    public AudioSource audioSource;
    public AudioClip literatureBGM;
    public AudioClip technologyBGM;
    public AudioClip historyBGM;
    public AudioClip artBGM;


    public void SwitchFloors(int targetFloor)
    {
        if (canSwitch && targetFloor != (int)Globals.selectedFloor) // don't allow user to switch floors during a switch
        {
            canSwitch = false;
            StartCoroutine(FadeOut(targetFloor));
        }
    }


    IEnumerator FadeOut(int floor)
    {
        float waitTime = 5f;
        float startTime = Time.time;
        float endTime = startTime + waitTime;


        while (Time.time < endTime)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0, (Time.time - startTime) / waitTime);
        }

        StartCoroutine(FadeIn(floor)); // when done, fade in the next floor
        yield return null;
    }


    IEnumerator FadeIn(int floor)
    {
        float waitTime = 5f;
        float startTime = Time.time;
        float endTime = startTime + waitTime;

        switch (floor)
        {
            case 0: audioSource.clip = historyBGM; break;
            case 1: audioSource.clip = technologyBGM; break;
            case 2: audioSource.clip = literatureBGM; break;
            case 3: audioSource.clip = artBGM; break;
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
