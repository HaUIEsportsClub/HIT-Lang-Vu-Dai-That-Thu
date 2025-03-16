using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerData playerData;
    private void OnEnable()
    {
        UIController_Scene1.checkDoKho += ChangeDoKho;
        if (playerData != null )
        playerData.startSpawnShadow = false;
    }
    private int dokho;
    private void ChangeDoKho(int dokho1)
    {
        dokho = dokho1;
    }
    public void ButtonPlay()
    {
        //print("play");
        switch (dokho)
        {
            case 0:
                SceneManager.LoadScene("Scene_2.1_Gameplay");
                break;
            case 1:
                SceneManager.LoadScene("Scene_2.2_Gameplay");
                break;
            case 2:
                SceneManager.LoadScene("Scene_2.3_Gameplay");
                break;
        }
    }

    public void ButtonSetting()
    {
        print("setting");
    }

    public void ButtonExit()
    {
        //print("exit");
        Application.Quit();
    }

    public void ButtonRank()
    {
        print("rank");
    }

    public void ButtonPause()
    {
        Time.timeScale = 1 - Time.timeScale;
    }
}
