using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCurrency : MonoBehaviour
{
    public GameObject currency;
    // Start is called before the first frame update
    void Start()
    {
     InvokeRepeating("spawn", 5, 5); //the currency will appear every 10 seconds    
    }
    void spawn()
    {
        Vector3 startingPos = new Vector3(0f,2.4f,-3.5f);
        Instantiate(currency, startingPos, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
