using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    bool canSwitch = true;
    public List<Transform> floors;
    Globals.floorType prevFloor;

    int prevFloorIndex = 0;
    int nextFloorIndex = 0;

    //Grab the Audio from the record player.
    public AudioSource recordPlayer;
    public AudioClip literatureBGM;
    public AudioClip technologyBGM;
    public AudioClip historyBGM;
    public AudioClip artBGM;


    public void SwitchFloors(int targetFloor)
    {
        if (canSwitch && targetFloor != (int)Globals.selectedFloor) // don't allow user to switch floors during a switch
        {
            canSwitch = false;

            prevFloor = Globals.selectedFloor;
            prevFloorIndex = (int)Globals.selectedFloor;
            Globals.selectedFloor = (Globals.floorType)targetFloor;
            nextFloorIndex = targetFloor;
                        
            Debug.Log("Fading out floor " + prevFloorIndex + ", fading in floor " + nextFloorIndex);
            StartCoroutine(FadeOut(floors[prevFloorIndex]));
        }      
    }


    IEnumerator FadeOut(Transform floor)
    {
        float waitTime = 5f;
        float startTime = Time.time;
        float endTime = startTime + waitTime;

        List<Transform> children = new List<Transform>();
        AddChildrenToList(floor, children);

        while (Time.time < endTime)
        {
            foreach (Transform item in children)
            {
                if (item.gameObject.GetComponent<MeshRenderer>() != null)
                {
                    Material mat = item.gameObject.GetComponent<MeshRenderer>().material;

                    mat.SetFloat("_Mode", 2); // set object rendering to fade mode, the rest is because of a known bug in Unity
                    mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    mat.SetInt("_ZWrite", 0);
                    mat.DisableKeyword("_ALPHATEST_ON");
                    mat.EnableKeyword("_ALPHABLEND_ON");
                    mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    mat.renderQueue = 3000;

                    Color matColor = mat.color;
                    matColor.a = Mathf.Lerp(matColor.a, 0, (Time.time - startTime) / waitTime);
                    mat.color = matColor;
                }
            }

            recordPlayer.volume = Mathf.Lerp(recordPlayer.volume, 0, (Time.time - startTime) / waitTime);

            yield return null;
        }

        foreach (Transform item in children) // make all objects inactive since they're not visible
            item.gameObject.SetActive(false);
        floor.gameObject.SetActive(false);

        StartCoroutine(FadeIn(floors[nextFloorIndex])); // when done, fade in the next floor
        yield return null;
    }


    IEnumerator FadeIn(Transform floor)
    { 
        float waitTime = 5f;
        float startTime = Time.time;
        float endTime = startTime + waitTime;

        switch (nextFloorIndex)
        {
            case 0: recordPlayer.clip = historyBGM; break;
            case 1: recordPlayer.clip = technologyBGM; break;
            case 2: recordPlayer.clip = literatureBGM; break;
            case 3: recordPlayer.clip = artBGM; break;
        }
        recordPlayer.Play();

        List<Transform> children = new List<Transform>();
        AddChildrenToList(floor, children);

        foreach (Transform item in children) 
        {
            item.gameObject.SetActive(true); // reactivate all objects to make them visible during fade in

            if (item.gameObject.GetComponent<MeshRenderer>() != null)
            {
                Material mat = item.gameObject.GetComponent<MeshRenderer>().material; // reset alpha to 0
                Color matColor = mat.color;
                matColor.a = 0;
                mat.color = matColor;

                mat.SetFloat("_Mode", 2);
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                mat.SetInt("_ZWrite", 0);
                mat.DisableKeyword("_ALPHATEST_ON");
                mat.EnableKeyword("_ALPHABLEND_ON");
                mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                mat.renderQueue = 3000;
            }            
        }
            
        floor.gameObject.SetActive(true);

        while (Time.time < endTime)
        {
            foreach (Transform item in children)
            {
                if (item.gameObject.GetComponent<MeshRenderer>() != null)
                {
                    Material mat = item.gameObject.GetComponent<MeshRenderer>().material;

                    Color matColor = mat.color;
                    matColor.a = Mathf.Lerp(matColor.a, 1, (Time.time - startTime) / waitTime);
                    mat.color = matColor;
                }
            }

            recordPlayer.volume = Mathf.Lerp(recordPlayer.volume, 1, (Time.time - startTime) / waitTime);

            yield return null;
        }

        foreach (Transform item in children) // set objects back to opaque after fading in
        {
            if (item.gameObject.GetComponent<MeshRenderer>() != null) 
            {
                Material mat = item.gameObject.GetComponent<MeshRenderer>().material;
                mat.SetFloat("_Mode", 0);
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                mat.SetInt("_ZWrite", 1);
                mat.DisableKeyword("_ALPHATEST_ON");
                mat.EnableKeyword("_ALPHABLEND_ON");
                mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                mat.renderQueue = -1;
            }
        }
       
        canSwitch = true;
        yield return null;
    }



    void AddChildrenToList(Transform parent, List<Transform> children)
    {
        foreach (Transform child in parent)
        {
            children.Add(child);
            AddChildrenToList(child, children);
        }         
    }
}
