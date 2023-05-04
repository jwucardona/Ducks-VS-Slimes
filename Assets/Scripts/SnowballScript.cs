using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
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
            other.GetComponentInParent<AbstractUnit>().TakeDamage(20);
            other.GetComponentInParent<SlimeUnit>().slowDown();
            Destroy(this.gameObject);
        }
    }
}
