using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BinahMovement : MonoBehaviour
{
    public float turnDistance;
    public float speed;
    float distanceCovered;


    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        distanceCovered += Math.Abs(speed * Time.deltaTime);
        if (distanceCovered >= turnDistance) {
            distanceCovered = 0;
            StartCoroutine(Rotate());
        }
    }


    IEnumerator Rotate()
    {
        float waitTime = 1f;
        float startTime = Time.time;
        float endTime = startTime + waitTime;

        Quaternion newRot = transform.rotation * Quaternion.Euler(0, 180, 0);
        while (Time.time < endTime)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, (Time.time - startTime) / waitTime);
            yield return null;
        }
        yield return null;
    }
}
