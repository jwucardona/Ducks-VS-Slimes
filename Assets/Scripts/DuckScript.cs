using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckScript : MonoBehaviour
{
    public GameObject bullet;
    bool shotFired;
    public Transform beakEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float timer = 0;
    int waitingTime = 1;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            Fire();
            timer = 0;
        }

        if (shotFired)
        {
            destroyShot();
        }
    }

    IEnumerator destroyShot()
    {
        yield return new WaitForSeconds(5f);
        Destroy(shot);
        shotFired = false;
    }

    GameObject shot;
    public void Fire()
    {
        shot = Instantiate(bullet, beakEnd.position, beakEnd.rotation);
        shot.GetComponent<Rigidbody>().AddForce(beakEnd.transform.forward * 500);
        shotFired = true;
    }
}
