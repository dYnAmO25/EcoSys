using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightCycle : MonoBehaviour
{
    public float fSpeed;
    public float fTransitionSpeed;
    public float fDayMinutes;
    public Color dayColor;
    public Color nightColor;
    public Material skyboxMaterial;
    public int iDay = 1;
    public GameObject directionalLightObject;
    public float fDayLight;
    public float fNightLight;
    public float fDayAtmosphere;
    public float fNightAtmosphere;
    public TMP_Text timeText;
    public TMP_Text dayText;

    private float fRotation = 0;
    private float fDayTime = 0;
    private bool bIsDay = true;
    private Light directionalLight;
    private float fAtmosphere = 1;

    private void Start()
    {
        directionalLight = directionalLightObject.GetComponent<Light>();
    }

    void Update()
    {
        fDayTime += (Time.deltaTime * fSpeed);

        fRotation = fDayTime / (fDayMinutes * 60) * 360;

        if (fRotation <= 180)
        {
            bIsDay = true;
        }
        else
        {
            fRotation -= 180;
            bIsDay = false;
        }

        if (fDayTime >= fDayMinutes * 60)
        {
            fDayTime = 0;
            iDay++;
        }

        if (bIsDay)
        {
            CycleToDay();
        }
        else
        {
            CycleToNight();
        }

        transform.rotation = Quaternion.Euler(new Vector3(fRotation, 0, 0));
        UpdateUI();
    }

    private void CycleToDay()
    {
        directionalLight.color = Color.Lerp(directionalLight.color, dayColor, fTransitionSpeed);
        directionalLight.intensity = Mathf.Lerp(directionalLight.intensity, fDayLight, fTransitionSpeed);
        fAtmosphere = Mathf.Lerp(fAtmosphere, fDayAtmosphere, fTransitionSpeed);
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", fAtmosphere);
        RenderSettings.skybox.SetFloat("_Exposure", fAtmosphere);

    }

    private void CycleToNight()
    {
        directionalLight.color = Color.Lerp(directionalLight.color, nightColor, fTransitionSpeed);
        directionalLight.intensity = Mathf.Lerp(directionalLight.intensity, fNightLight, fTransitionSpeed);
        fAtmosphere = Mathf.Lerp(fAtmosphere, fNightAtmosphere, fTransitionSpeed);
        RenderSettings.skybox.SetFloat("_Exposure", fAtmosphere);
    }

    private void UpdateUI()
    {
        dayText.text = "Day " + iDay.ToString();

        float fTime = fDayTime / (fDayMinutes * 60);

        int iHour = (int)(24 * fTime);
        iHour += 6;
        iHour %= 24;
        int iMinute = (int)(60 * 24 * fTime);
        iMinute %= 60;
        
        if (iHour < 10)
        {
            if (iMinute < 10)
            {
                timeText.text = "0" + iHour.ToString() + ":0" + iMinute.ToString();

            }
            else
            {
                timeText.text = "0" + iHour.ToString() + ":" + iMinute.ToString();
            }
        }
        else
        {
            if (iMinute < 10)
            {
                timeText.text = iHour.ToString() + ":0" + iMinute.ToString();
            }
            else
            {
                timeText.text = iHour.ToString() + ":" + iMinute.ToString();
            }
        }
    }
}
