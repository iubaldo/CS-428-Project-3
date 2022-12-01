using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteNightEvent : MonoBehaviour
{
    public GameObject whiteNight;
    public GameObject UI;
    public GameObject door;
    public Camera gameCamera;
    public Material skyboxMat;


    public void Transition()
    {
        UI.SetActive(true);
        whiteNight.SetActive(true);
        
    }


    public void OpenDoor()
    {
        door.SetActive(false);
        //for (int i = 0; i < 100; i++)
        //{
        //    door.transform.position += Vector3.right * 0.01f;
        //}
    }
}
