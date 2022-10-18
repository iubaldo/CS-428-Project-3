using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IanCollisionSound : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider collision;
    AudioSource ianVoice;
    private float coolDown = 13.5f;
    private bool talks = false;

    void Start()
    {
        ianVoice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (talks == false)
        {
            ianVoice.Play();
            StartCoroutine(CoolDown());
        }
        
    }

    IEnumerator CoolDown() {
        talks = true;
        yield return new WaitForSeconds(coolDown);
        talks = false;
    }

}
