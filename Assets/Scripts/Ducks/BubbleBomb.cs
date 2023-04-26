using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBomb : DuckUnit
{
    // Constructor
    public GameObject bombParticles;
    //if planted bombParticles.setActive(true);
    public BubbleBomb() : base(10000, 1800, 1.2f, 150, 50.0f)
    {
    }
    IEnumerator bomb()
    {
        bombParticles.SetActive(true);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //if enemy within certain distance 
        //StartCoroutine(bomb());
        //kill enemies within certain range / turn them black
    }
}
