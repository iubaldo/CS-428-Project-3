using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class binahMovement : MonoBehaviour
{
    [SerializeField]float distance;
    [SerializeField] float speed;
    private Vector3 startingPosition;
    float distanceCovered;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = startingPosition;
        v.x +=  speed *Time.deltaTime;
        distanceCovered += Math.Abs(speed* Time.deltaTime);
        if (distanceCovered >= distance) {
            speed = speed * -1;
            distanceCovered = 0;
            //transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        transform.position = v;
    }
}
