using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currencyClick : MonoBehaviour
{
    public static int score = 100;

    void OnMouseDown() 
    {
        // Increase Score
        print("should be destroying water drop");
        score += 20;

        // Destroy Sun
        Destroy(gameObject);
    }
}
