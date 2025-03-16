using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public static Action<string> dungchieu;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerControlData playerControlData;
    private TMP_Text curTime;
    private Image skill1, skill2, skill3, skill4;
    private float timeSkill1, timeSkill2, timeSkill3, timeSkill4;
    private bool check1, check2, check3, check4;
    private void Awake()
    {
        curTime = gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        skill1 = gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();
        skill2 = gameObject.transform.GetChild(2).gameObject.GetComponent<Image>();
        skill3 = gameObject.transform.GetChild(3).gameObject.GetComponent<Image>();
        skill4 = gameObject.transform.GetChild(4).gameObject.GetComponent<Image>();
        PlayerController.EvenCurTime += EvenCurTime;
        check1 = false;
        check2 = false;
        check3 = false;
        check4 = false;
    }

    private void EvenCurTime(float time)
    {
        curTime.text = LamTron(time).ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playerControlData.keyU))
        {
            if (timeSkill1 == playerData.timeSkill.speedUp && playerData.skillKeyU)
            {
                dungchieu?.Invoke("KeyU");
                skill1.fillAmount = 0;
                check1 = true;
                playerData.skillKeyU = false;
            }
        }
        if (Input.GetKeyDown(playerControlData.keyI))
        {
            if (timeSkill2 == playerData.timeSkill.teleportation && playerData.skillKeyI)
            {
                dungchieu?.Invoke("KeyI");
                skill2.fillAmount = 0;
                check2 = true;
                playerData.skillKeyI = false;
            }
        }
        if (Input.GetKeyDown(playerControlData.keyO))
        {
            if (timeSkill3 == playerData.timeSkill.reverseShadow)
            {
                skill3.fillAmount = 0;
                check3 = true;
            }
        }
        if (Input.GetKeyDown(playerControlData.keyP))
        {
            if (timeSkill4 == playerData.timeSkill.magicEye)
            {
                skill4.fillAmount = 0;
                check4 = true;
            }
        }

        if (check1)
        {
            StartCoroutine(Check(timeSkill1, skill1));
            check1 = false;
        }
        if (check2)
        {
            StartCoroutine(Check(timeSkill2, skill2));
            check2 = false;
        }
        if (check3)
        {
            StartCoroutine(Check(timeSkill3, skill3));
            check3 = false;
        }
        if (check4)
        {
            //StartCoroutine(Check(timeSkill1, skill1));
            //check1 = false;
        }
        if (skill1.fillAmount == 1)
        {
            playerData.skillKeyU = true;
        }
        if (skill2.fillAmount == 1)
        {
            playerData.skillKeyI = true;
        }
    }

    IEnumerator Check(float timeSkill, Image skill)
    {
        if (timeSkill < 0) yield return null;
        yield return new WaitForSeconds(timeSkill / 10f);
        skill.fillAmount += 0.1f;
        StartCoroutine(Check(timeSkill, skill));
    }

    private void SetupButton()
    {
        timeSkill1 = playerData.timeSkill.speedUp;
        timeSkill2 = playerData.timeSkill.teleportation;
        timeSkill3 = playerData.timeSkill.reverseShadow;
        timeSkill4 = playerData.timeSkill.magicEye;
    }

    private float LamTron(float n)
    {
        return (int)(n * 100) / 100f;
    }
}