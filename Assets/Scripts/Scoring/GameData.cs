using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int[] highScores;

    public GameData()
    {
        highScores = new int[10];
        Debug.Log("GameData Instantiated");
    }
}
