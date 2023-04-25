using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckUnit : AbstractUnit
{
    // Declare the variables
    float interval;
    int cost;
    protected float recharge;

    // Constructor
    public DuckUnit(int hp, int dmg, float interval, int cost, float recharge) : base(hp, dmg)
    {
        // Set the default values
        this.interval = interval;
        this.cost = cost;
        this.recharge = recharge;
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
