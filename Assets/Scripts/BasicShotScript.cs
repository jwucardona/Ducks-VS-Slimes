using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShotScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 8)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 || other.tag == "Enemy")
        {
            print("TEST");
            other.GetComponentInParent<AbstractUnit>().TakeDamage(20);
            Destroy(this.gameObject);
        }
        if (other.tag != "Duck")
        {
            print("test");
        }
    }
}
