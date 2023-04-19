using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractUnit : MonoBehaviour
{
    // Declare the variables
    public int health;
    public int damage;


    // Constructor
    public AbstractUnit(int hp, int dmg)
    {
        // Set the default values
        this.health = hp;
        this.damage = dmg;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
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
