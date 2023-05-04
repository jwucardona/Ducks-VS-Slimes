using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScript : MonoBehaviour
{
    [SerializeField] private TMP_Text endText;
    private static bool winner = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winner) {
            endText.text = "You Win!";
        } else {
            endText.text = "You Lose!";
        }
    }

    public static void Win() {
        winner = true;
    }

    public static void Lose() {
        winner = false;
    }
}
