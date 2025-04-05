using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "MyConfigs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public PlayerData[] playerDatas;
}


[Serializable]
public struct PlayerData
{
    public string playerName;

    public Color color;
    public PlayerRole playerRole;

    public Transform pawn;
}
