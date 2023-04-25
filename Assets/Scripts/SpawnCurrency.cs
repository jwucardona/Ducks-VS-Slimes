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
     private Ray ray; // The ray
     private RaycastHit hit; // What we hit
     public static int money = 100;
     void Update()
     {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Ray will be sent out from where your mouse is located    
         if(Physics.Raycast(ray,out hit, 1000.0f) && Input.GetMouseButtonDown (0)) // On left click we send down a ray
         {
            if(hit.collider.gameObject.tag == "WaterDrop")
            {
              Destroy (hit.collider.gameObject); 
              money+=25;
            }
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
