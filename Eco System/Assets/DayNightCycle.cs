using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float fSpeed;
    public float fDayMinutes;
    public Color dayColor;
    public Color nightColor;
    public Material skyboxMaterial;
    public GameObject directionalLight;

    private float fRotation = 0;
    private float fDayTime = 0;

    void Update()
    {
        fDayTime += (Time.deltaTime * fSpeed);

        fRotation = fDayTime / (fDayMinutes * 60) * 360;

        // Day Cycle
        if (fRotation <= 180)
        {

        }
        // Night Cycle
        else
        {
            fRotation -= 180;
        }

        transform.rotation = Quaternion.Euler(new Vector3(fRotation, 0, 0));

        if (fDayTime >= fDayMinutes * 60)
        {
            fDayTime = 0;
        }
    }
}
