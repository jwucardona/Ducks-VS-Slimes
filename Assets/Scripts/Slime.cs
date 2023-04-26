using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Slime
{
    public int spawnTime;
    public SlimeType slimeType;
    public int Spawner;
    public bool RandomSpawn;
    public bool isSpawned;
}

public enum SlimeType
{
    Basic_Slime,
    Viking_Slime,
    Knight_Slime,
    King_Slime
}
