using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// trimmed down version of EGOSpawner, doesn't check for money
public class EGOSpawnerLite : MonoBehaviour
{
    public GameObject spawnPoint;

    public List<GameObject> EGOList;

    public float timeLastDispensed = 0;
    public float dispenseCD = 1;


    // spawns a copy of the selected item
    public void Dispense(int index)
    {
        if (Time.time < timeLastDispensed + dispenseCD)
            return;

        timeLastDispensed = Time.time;

        GameObject item;
        item = Instantiate(EGOList[index], spawnPoint.transform.position, Quaternion.identity * Quaternion.Euler(0, 0, 90));
    }
}
