using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform player;

    public Transform telepoint1;
    public Transform telepoint2;
    public Transform telepoint3;
    public Transform telepoint4;
    public Transform telepoint5;
    public Transform telepoint6;


    public void teleportPlayer(int index)
    {
        Debug.Log("teleporting to " + index);
        switch (index) 
        {
            case 1: player.position = telepoint1.position; break;
            case 2: player.position = telepoint2.position; break;
            case 3: player.position = telepoint3.position; break;
            case 4: player.position = telepoint4.position; break;
            case 5: player.position = telepoint5.position; break;
            case 6: player.position = telepoint6.position; break;
            default: player.position = telepoint1.position; break;
        }

    }
}
