using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBomb : DuckUnit
{
    // Constructor
    public GameObject bombParticles;
    public GameObject bubbleBomb;
    //if planted bombParticles.setActive(true);
    public BubbleBomb() : base(10000, 1800, 1.2f, 150, 50.0f)
    {
    }
    void Start()
    {
        
    }
    IEnumerator bomb()
    {
        checkCol = false;
        print(toKill.Count);
        bombParticles.SetActive(true);
        for(int i = 0; i < toKill.Count; i++)
        {
            //toKill[i].GetComponent<Renderer>().material.color = Color.black;
            if(toKill[i] != null)
                Destroy(toKill[i].gameObject);
        }
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
    bool checkCol = true;
    int count = 0;
    List<SlimeUnit> toKill = new List<SlimeUnit>();
    void OnTriggerEnter(Collider col)
    {
        if(checkCol)
        {
        Collider[] colliders = Physics.OverlapSphere(bubbleBomb.transform.position, 4);
        foreach (var collider in colliders)
        {
            print(collider.tag);
            if(collider.tag == "Enemy")
            {
                //go through all enemies and add to list in for loop here ?
                toKill.Add(collider.gameObject.GetComponent<SlimeUnit>());
                //startBomb = true;
            }
        }
        }
        StartCoroutine(bomb());
        /*startBomb = true;
        if(startBomb)
        {
            StartCoroutine(bomb());
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        //if enemy within certain distance 
        //StartCoroutine(bomb());
        //kill enemies within certain range / turn them black
    }
}
