using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDuck : DuckUnit
{
    // Constructor
    public BubbleDuck() : base(300, 0, 24.25f, 50, 7.5f)
    {
    }

    public GameObject waterDrop;
    public Transform beakEnd;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        currencyMover.velocity.y = 0.25f;
        timer = interval - 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(shot != null)
        {
            if(shot.transform.position.y >= 4)
            {
            StartCoroutine(freeze());
            }
            else
            {
                currencyMover.velocity.y = 0.25f;
            }
        }
        timer += Time.deltaTime;
        if (timer > interval)
        {
            spawnCurrency();
            timer = 0;
        }
    }
    GameObject shot;
    public void spawnCurrency()
    {
        shot = Instantiate(waterDrop, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation);

    }
    IEnumerator freeze()
    {
        currencyMover.velocity.y = .01f;
        yield return new WaitForSeconds(4f);
        Destroy(shot.gameObject);
    }
    
}
