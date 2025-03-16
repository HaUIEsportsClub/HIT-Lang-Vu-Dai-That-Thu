using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorr : MonoBehaviour
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        UIController_Scene1.checkColorr += Change;
    }

    private void Change(Color color)
    {
        image.color = color;
    }
}
