using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDuck : DuckUnit
{
    // Constructor
    public BubbleDuck() : base(300, 0, 24.25f, 50, 7.5f)
    {
    }

    public GameObject waterDrop;
    public Transform beakEnd;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = recharge - 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > recharge)
        {
            spawnCurrency();
            timer = 0;
        }
    }

    GameObject shot;
    public void spawnCurrency()
    {
        shot = Instantiate(waterDrop, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), transform.rotation);
    }
}
