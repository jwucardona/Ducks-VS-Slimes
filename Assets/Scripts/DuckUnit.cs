using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckUnit : AbstractUnit
{
    // Declare the variables
    protected float interval;
    int cost;
    protected float recharge;

    private List<SlimeUnit> attackers = new List<SlimeUnit>();

    //protected List<SlimeUnit> attackers;

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

    bool foundAttacker;
    public void TakeDamageForDucks(int dmg, SlimeUnit slimeAttacker)
    {
        foundAttacker = false;
        for (int i = 0; i < attackers.Count; i++)
        {
            if (attackers[i] == slimeAttacker)
            {
                foundAttacker = true;
            }
        }
        if (!foundAttacker)
        {
            attackers.Add(slimeAttacker);
            //print(slimeAttacker);
        }
        
        gc = GameControllerScript.getInstance();
        health -= dmg;
        //print("damage taken");
        if (health <= 0)
        {
            health = 0;
            die();
            //gc.deadDuck(this.gameObject);
            //Destroy(this.gameObject);
        }
    }

    public List<SlimeUnit> getAttackers()
    {
        return attackers;
    }

    public override void die()
    {
         gc.deadDuck(this, gameObject.transform.position.x, gameObject.transform.position.z);
    }
}
