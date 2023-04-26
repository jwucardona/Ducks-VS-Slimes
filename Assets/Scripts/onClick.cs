using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour
{

    void OnMouseDown() 
    {
        // Increase Score
        print("should be destroying water drop");
        SpawnCurrency.money += 20;

        // Destroy waterdrop
        Destroy(gameObject);
    }
}
