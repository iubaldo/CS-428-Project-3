using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGO : MonoBehaviour
{
    public AudioSource audioSource;

    // combat stats if I get to it
    public bool ranged = false;
    public float shootCD = 1;
    public float timeLastShot = 0;

 
    public void OnHit(GameObject target) // for melee weapons only
    {
        if (target.CompareTag("enemy"))
        {
            EGOSpawner.spawnCoinSignal = true;
        }
    }


    public void OnShoot() // for ranged weapons only
    {
        if (Time.time > timeLastShot + shootCD)
            return;

        timeLastShot = Time.time;
        audioSource.Play();
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (!ranged && collision.relativeVelocity.magnitude > 1)
        {
            audioSource.Play();
            OnHit(collision.gameObject);
        }
    }
}
