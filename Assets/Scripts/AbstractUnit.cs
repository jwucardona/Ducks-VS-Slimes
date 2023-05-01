using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractUnit : MonoBehaviour
{
    // Declare the variables
    public int health;
    public int damage;

    protected GameControllerScript gc;

    // Constructor
    public AbstractUnit(int hp, int dmg)
    {
        // Set the default values
        this.health = hp;
        this.damage = dmg;
    }

    public void TakeDamage(int dmg)
    {
        gc = GameControllerScript.getInstance();
        health -= dmg;
        if (health <= 0)
        {
            health = 0;
            die();
            //gc.deadDuck(this.gameObject);
            //Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //gc = GameControllerScript.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // override in children
    public virtual void die()
    {
    }
}
