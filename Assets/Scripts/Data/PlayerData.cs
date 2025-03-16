using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData/new PlayerData")]
public class PlayerData : ScriptableObject
{
    public float jump;
    public float speed;
    public TimeSkill timeSkill;
    public int countShadow;
    public float distance;
    public float rayLength;
    public LayerMask groundLayer;
    public float timeSpawnShadow;
    public Vector2 posRespawn;
    public bool startSpawnShadow;

    public bool skillKeyI;
    public bool skillKeyU;

    public bool isTele;
}

[System.Serializable]
public struct TimeSkill
{
    public float speedUp;
    public float teleportation;
    public float reverseShadow;
    public float magicEye;
}