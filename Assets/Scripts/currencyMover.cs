using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currencyMover : MonoBehaviour
{
    public static Vector2 velocity;

    void FixedUpdate ()
    {
        GetComponent<Rigidbody>().velocity = velocity;
    }
}

