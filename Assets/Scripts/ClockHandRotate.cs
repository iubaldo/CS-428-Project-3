using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHandRotate : MonoBehaviour
{
    public float rotateSpeed = 0f;


    void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(Vector3.right * rotateSpeed * Time.deltaTime);
    }
}
