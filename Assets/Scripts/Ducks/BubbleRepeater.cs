using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleRepeater : DuckUnit
{
    // Constructor
    public BubbleRepeater() : base(300, 20, 1.425f, 200, 7.5f)
    {
    }
    public GameObject basicShot;
    public Transform beakEnd;

    float timer = 0;
    int count = 0;

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
            if (count == 0)
            {
                Shoot();
                timer = interval - 0.1f;
                count++;
            }
            else if (count == 1)
            {
                Shoot();
                timer = 0;
                count = 0;
            }
        }
    }

    GameObject shot;
    public void Shoot()
    {
        shot = Instantiate(basicShot, beakEnd.position, beakEnd.rotation);
        shot.GetComponent<Rigidbody>().AddForce(beakEnd.transform.forward * 500);
    }
}
