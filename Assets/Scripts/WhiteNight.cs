using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteNight : MonoBehaviour
{
    public Transform player;


    private void Start()
    {
        StartCoroutine(FloatDown());
    }


    void Update()
    {
        transform.LookAt(player);
        transform.Rotate(new Vector3(90, 0, 0));
    }


    IEnumerator FloatDown()
    {
        float waitTime = 1.5f;
        float startTime = Time.time;
        float endTime = startTime + waitTime;

        Vector3 newPos = transform.position - Vector3.down;
        while (Time.time < endTime)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, (Time.time - startTime) / waitTime);
            yield return null;
        }

        StartCoroutine(FloatUp());
        yield return null;
    }


    IEnumerator FloatUp()
    {
        float waitTime = 1.5f;
        float startTime = Time.time;
        float endTime = startTime + waitTime;

        Vector3 newPos = transform.position - Vector3.up;
        while (Time.time < endTime)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, (Time.time - startTime) / waitTime);
            yield return null;
        }

        StartCoroutine(FloatDown());
        yield return null;
    }
}
