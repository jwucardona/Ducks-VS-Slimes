using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    public GameObject boat;
    private bool active = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            // when we add in damage for the slimes, change this to do other.Kill() or other.TakeDamage()
            Destroy(other.gameObject);
        }
        if (other.gameObject.layer == 10)
        {
            Destroy(boat);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active){
            transform.Translate(new Vector3(0, 0, 0.005f * 1));
        }
    }
}
