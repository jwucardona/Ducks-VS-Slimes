using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [System.Serializable]
public class Slime
{
    public int spawnTime;
    public int slimeType;
    public int Spawner;
    public bool RandomSpawn;
    public bool isSpawned;

    // constructor
    public Slime(int spawnTime, int slimeType, int Spawner, bool RandomSpawn, bool isSpawned)
    {
        this.spawnTime = spawnTime;
        this.slimeType = slimeType;
        this.Spawner = Spawner;
        this.RandomSpawn = RandomSpawn;
        this.isSpawned = isSpawned;
    }
}

/*public enum SlimeType
{
    Basic_Slime,
    Viking_Slime,
    Knight_Slime,
    King_Slime
}*/
