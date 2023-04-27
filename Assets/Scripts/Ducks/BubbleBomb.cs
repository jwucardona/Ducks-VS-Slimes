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
    void Start()
    {
        
    }
    IEnumerator bomb()
    {
        print("bombing");
        bombParticles.SetActive(true);
        for(int i = 0; i < toKill.Count; i++)
        {
            //toKill[i].GetComponent<Renderer>().material.color = Color.black;
            yield return new WaitForSeconds(1f);
            Destroy(toKill[i]);
        }
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
    bool startBomb = false;
    int count = 0;
    List<SlimeUnit> toKill = new List<SlimeUnit>();
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy" && !startBomb)
        {
            toKill.Add(col.gameObject.GetComponent<SlimeUnit>());
            startBomb = true;
        }
        if(startBomb)
        {
            StartCoroutine(bomb());
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if enemy within certain distance 
        //StartCoroutine(bomb());
        //kill enemies within certain range / turn them black
    }
}
