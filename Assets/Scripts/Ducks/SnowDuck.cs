using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowDuck : DuckUnit
{
    // Constructor
    public SnowDuck() : base(300, 20, 1.425f, 175, 7.5f)
    {
    }
    public GameObject snowball;
    public Transform beakEnd;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = interval - 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Shoot();
            timer = 0;
        }
    }

    GameObject shot;
    public void Shoot()
    {
        shot = Instantiate(snowball, beakEnd.position, beakEnd.rotation);
        shot.GetComponent<Rigidbody>().AddForce(beakEnd.transform.forward * 500);
    }
}
