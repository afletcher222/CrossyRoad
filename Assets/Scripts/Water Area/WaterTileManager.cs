using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaterType { pad, log }

public class WaterTileManager : MonoBehaviour
{
    public WaterType type;

    private void Awake()
    {
        if (Random.value > .5)
        {
            type = WaterType.pad;
        }
        else
        {
            type = WaterType.log;
        }
    }
}