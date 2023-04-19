using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeUnit : AbstractUnit
{
    // Declare the variables
    float speed;
    // Constructor
    public SlimeUnit(int hp, int dmg, float speed) : base(hp, dmg)
    {
        // Set the default values
        this.speed = speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
