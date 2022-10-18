using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider collision;
    AudioSource robVoice;
    private float coolDown = 13.5f;
    private bool talks = false;

    void Start()
    {
        robVoice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (talks == false)
        {
            robVoice.Play();
            StartCoroutine(CoolDown());
        }

    }

    IEnumerator CoolDown()
    {
        talks = true;
        yield return new WaitForSeconds(coolDown);
        talks = false;
    }
}
