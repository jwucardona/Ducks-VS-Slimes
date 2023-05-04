using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleDuckMover : MonoBehaviour
{
    public static bool isBubDuck = false;
    public static Vector3 duckLoc;
    public GameObject drop;
    // Start is called before the first frame update
    void Start() 
    {
        // Spawn first Sun in 10 seconds, repeat every 10 seconds
        InvokeRepeating("spawn", 10, 10);
    }
    void spawn()
    {
        if(isBubDuck)
        {
            Instantiate(drop, duckLoc, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
