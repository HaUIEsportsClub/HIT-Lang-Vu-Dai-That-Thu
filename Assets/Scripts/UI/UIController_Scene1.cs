using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController_Scene1 : MonoBehaviour
{
    public static Action<int> checkDoKho;
    public static Action<Color> checkColorr;
    private Slider slider;
    private float maxValue;
    private GameObject obj;
    private GameObject obj1;
    private Image image;
    private Image image1;

    private float constt = 255f / 3;

    private void Start()
    {
        slider = GetComponent<Slider>();
        maxValue = 3f;
        slider.maxValue = maxValue;
        slider.value = 0;
        obj = transform.GetChild(2).GetChild(0).GetChild(1).gameObject;
        obj1 = transform.GetChild(1).GetChild(0).gameObject;
        image = obj.GetComponent<Image>();
        image1 = obj1.GetComponent<Image>();
        CheckBar.checkBar += CheckBarr;
    }

    private void Update()
    {
        if (slider.value <= maxValue / 2f)
        {
            ChangeColor(new Color((constt * slider.value) / 255, 1, 0));
        }
        else
        {
            ChangeColor(new Color(255, (255 - constt * slider.value) / 255, 0));
        }
        if (slider.value <= 0.25f * maxValue)
        {
            checkDoKho?.Invoke(0);
        }
        else if (slider.value <= maxValue * 0.75f)
        {
            checkDoKho?.Invoke(1);
        }
        else
        { checkDoKho?.Invoke(2); }
    }

    private void CheckBarr(bool bl)
    {
        if (slider.value < 0.25f * maxValue)
        {
            for (float i = slider.value; i > 0; i -= Time.deltaTime)
            {
                if (i < 0) i = 0;
                slider.value = i;
            }
        }
        else if (slider.value < 0.75f * maxValue)
        {
            if (slider.value < 0.5 * maxValue)
            {
                for (float i = slider.value; i < 0.5f * maxValue;  i += Time.deltaTime)
                {
                    if (i > 0.5f * maxValue) i = 0.5f * maxValue;
                    slider.value = i + 0.1f;
                }
            }
            else
            {
                for (float i = slider.value; i > 0.5f * maxValue;  i -= Time.deltaTime)
                {
                    if (i < 0.5f * maxValue) i = 0.5f * maxValue;
                    slider.value = i;
                }
            }
        }
        else
        {
            for (float i = slider.value; i < maxValue; i += Time.deltaTime)
            {
                if (i > maxValue) i = maxValue;
                slider.value = i;
            }
        }
    }

    private void ChangeColor(Color color)
    {
        image.color = color;
        image1.color = color;
        checkColorr?.Invoke(color);
    }
}
