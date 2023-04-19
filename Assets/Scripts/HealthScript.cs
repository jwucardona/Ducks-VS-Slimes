using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    int curHealth = 5;
    //method to take damage
    public void damage(int amount)
    {
        curHealth -= amount;
        if(curHealth == 0)
        {
            //destroy(GameObject);
        }
    }
}
