using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public float fSpeedRotation;
    public float fSpeedHeight;

    private float fRotation = 0;
    private float fHeight= 0;

    // Update is called once per frame
    void Update()
    {
        fRotation += fSpeedRotation * Time.deltaTime;
        fHeight += fSpeedHeight * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(0, fRotation, 0));
        transform.position = new Vector3(0, Mathf.Sin(fHeight), 0);
    }
}
