using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShooter : DuckUnit
{
    // Constructor
    public BubbleShooter() : base(300, 20, 1.425f, 100, 7.5f)
    {
    }
    public GameObject basicShot;
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
            Shoot();
            timer = 0;
        }
    }

    GameObject shot;
    public void Shoot()
    {
        shot = Instantiate(basicShot, beakEnd.position, beakEnd.rotation);
        shot.GetComponent<Rigidbody>().AddForce(beakEnd.transform.forward * 500);
    }
}
