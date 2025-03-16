using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBar : MonoBehaviour
{
    public static Action<bool> checkBar;
    private void OnMouseDown()
    {
        checkBar?.Invoke(true);
    }

    private void OnMouseExit()
    {
        checkBar?.Invoke(true);
    }
}
