using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGOSpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    
    public List<GameObject> historyEGO;
    public List<GameObject> technologyEGO;
    public List<GameObject> literatureEGO;
    public List<GameObject> artEGO;

    public GameObject coinSpawnPoint;
    public GameObject coinSpawnPoint2;
    public GameObject coinPrefab;


    public float timeLastDispensed = 0;
    public float dispenseCD = 1;

    public static bool spawnCoinSignal = false;


    private void Update()
    {
        if (spawnCoinSignal)
        {
            spawnCoinSignal = false;
            SpawnCoin(coinSpawnPoint2);
        }
    }


    // spawns a copy of the selected item
    public void Dispense(int index)
    {
        if (Time.time < timeLastDispensed + dispenseCD || Globals.currentMoney <= 0) // money check
            return;

        timeLastDispensed = Time.time;

        GameObject item;
        switch(Globals.selectedFloor)
        {
            case Globals.floorType.history:
                item = Instantiate(historyEGO[index], spawnPoint.transform.position, Quaternion.identity * Quaternion.Euler(0, 0, 90));
                break;
            case Globals.floorType.technology:
                item = Instantiate(technologyEGO[index], spawnPoint.transform.position, Quaternion.identity * Quaternion.Euler(0, 0, 90));
                break;
            case Globals.floorType.literature:
                item = Instantiate(literatureEGO[index], spawnPoint.transform.position, Quaternion.identity * Quaternion.Euler(0, 0, 90));
                break;
            case Globals.floorType.art:
                item = Instantiate(artEGO[index], spawnPoint.transform.position, Quaternion.identity * Quaternion.Euler(0, 0, 90));
                break;
        }

        Globals.currentMoney -= 1;
    }


    public void SpawnCoin()
    {
        if (Time.time < timeLastDispensed + dispenseCD) // money check
            return;

        timeLastDispensed = Time.time;
        Instantiate(coinPrefab, coinSpawnPoint.transform.position, Quaternion.identity);
    }


    // overload
    public void SpawnCoin(GameObject spawnPoint)
    {
        if (Time.time < timeLastDispensed + dispenseCD) // money check
            return;

        timeLastDispensed = Time.time;
        Instantiate(coinPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
