using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCurrency : MonoBehaviour
{
    public float min;
    public float max;
    public float time;
    public GameObject waterDrop;
    public Vector3 minPos;
    public Vector3 maxPos;
    
    Vector3 pos;

    private void Start()
    {
        time = Random.Range(min, max);
        pos.x = Random.Range(minPos.x, maxPos.x);
        pos.y = Random.Range(minPos.y, maxPos.y);
        pos.z = Random.Range(minPos.z, maxPos.z);
        StartCoroutine(spawn());
    }
    public IEnumerator spawn()
    {
        yield return new WaitForSeconds(time);
        Instantiate(waterDrop, pos, Quaternion.identity);
        time = Random.Range(min, max);
        pos.x = Random.Range(minPos.x, maxPos.x);
        pos.y = Random.Range(minPos.y, maxPos.y);
        pos.z = Random.Range(minPos.z, maxPos.z);
       StartCoroutine(spawn());
    }
    void OnCollisionEnter(Collision co)
    {
        if(co.gameObject.tag == "WaterDrop")
        {
            print("collsion");
            Destroy(co.gameObject);
        }
    }
    /*public GameObject currency;
    // Start is called before the first frame update
    void Start()
    {
        currency.SetActive(false);
        InvokeRepeating("spawn", 5, 5); //the currency will appear every 5 seconds    
    }
    void spawn()
    {
        currency.SetActive(true);
        Vector3 startingPos = new Vector3(3f,-3f,-1.5f);
        Instantiate(currency, startingPos, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }*/
}
