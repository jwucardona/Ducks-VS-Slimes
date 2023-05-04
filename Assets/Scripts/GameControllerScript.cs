using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameControllerScript : MonoBehaviour
{
    TileScript[] tiles;
    public static List<GameObject> ducks = new List<GameObject>();

    private TileScript start, end;

    public GameObject duckDefaultPrefab;

    public List<TileScript> temp = new List<TileScript>();
    public List<TileScript> path = new List<TileScript>();
    //public TurnControl tc = new TurnControl();

    public Camera cam;
    private Material newColor;
    TileScript tileTarget;

    public static bool shopActive = false;
    public static bool removeDefense = false;

    private static GameControllerScript theGameController;

    public static GameControllerScript getInstance()
    {
        return theGameController;
    }

    System.Random rnd = new System.Random();

    List<GameObject> enemyPrefabList = new List<GameObject>();

    public void GameOver(){
        // make game over?
        print("Game Over");
    }

    // Start is called before the first frame update
    void Start()
    {

        theGameController = this;


        tiles = FindObjectsOfType<TileScript>();
        for (int i = 0; i < tiles.Length; i++)
        {
            for (int j = i + 1; j < tiles.Length; j++)
            {
                if (Vector3.Distance(tiles[i].transform.position, tiles[j].transform.position) < 2.1f) {
                    tiles[i].getNeighbors().Add(tiles[j]);
                    tiles[j].getNeighbors().Add(tiles[i]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Checking free squares
        /*for(int i=0; i<ducks.Count; i++){
            for(int j=0; j<tiles.Length; j++){
                if (ducks[i].transform.position.x == tiles[j].transform.position.x && ducks[i].transform.position.z == tiles[j].transform.position.z){
                    tiles[j].GetComponent<TileScript>().setTaken(true);
                }else{
                    tiles[j].GetComponent<TileScript>().setTaken(false);
                }
            }
        }*/

        Ray ray;
        RaycastHit hit;
        ray = cam.ScreenPointToRay(Input.mousePosition); // Ray will be sent out from where your mouse is located
         if(Physics.Raycast(ray,out hit, 100.0f) && Input.GetMouseButtonDown (0)) // On left click we send down a ray
         {
            if(hit.collider.gameObject.tag == "WaterDrop")
            {
              Destroy (hit.collider.gameObject);
              SpawnCurrency.setCurrency();
            }
         }
        if(start != null && end != null){
            computerPath(start, end);
        }

        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].setColor(tiles[i].getColor());
            if (tileTarget != null)
            {
                tileTarget.setColor(Color.blue * 2);
            }
        }
        //TESTER CODE TO PLACE DUCKS AT ANY POINT IN THE GAME
        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null && hit.transform.tag == "Tile")
                {
                    tileTarget = hit.transform.gameObject.GetComponent<TileScript>();
                }
            }
        }
        if (tileTarget != null && Input.GetKeyDown(KeyCode.Return))
        {
            GameObject newObject = Instantiate(duckDefaultPrefab, new Vector3(tileTarget.transform.position.x, 1f, tileTarget.transform.position.z), transform.rotation * Quaternion.Euler(270f, 90f, 0f));
            tileTarget = null;
        }*/

        //CODE TO PLACE DUCKS ONLY WHEN SHOP IS OPEN
        if(shopActive){
            //HIGHLIGHT SQUARES
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit) && hit.transform.tag == "Tile" && !hit.collider.transform.gameObject.GetComponent<TileScript>().getTaken()){
                hit.collider.transform.gameObject.GetComponent<TileScript>().setColor(Color.blue * 2);
            }
            //SET POSITION
            if (Input.GetMouseButtonDown(0))
            {
                ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform != null && hit.transform.tag == "Tile" && !hit.collider.transform.gameObject.GetComponent<TileScript>().getTaken())
                    {
                        tileTarget = hit.transform.gameObject.GetComponent<TileScript>();

                    }

                }


            }
            if (tileTarget != null)
            {
                GameObject newObject = Instantiate(ShopScript.getCurrDefense(), new Vector3(tileTarget.transform.position.x, 1f, tileTarget.transform.position.z), transform.rotation * Quaternion.Euler(270f, 90f, 0f));
                ducks.Add(newObject);
                if(newObject.tag == "Bubble Shooter"){
                    ShopScript.startBSTimer = true;
                    print("BS Timer started");
                }
                if(newObject.tag == "Bubble Duck 2"){
                    ShopScript.startBDTimer = true;
                    print("BD Timer started");
                }
                if(newObject.tag == "Bubble Repeater"){
                    ShopScript.startBRTimer = true;
                    print("BR Timer started");
                }
                if(newObject.tag == "Bubble Bomb"){
                    ShopScript.startBBTimer = true;
                    print("BB Timer started");
                }
                if(newObject.tag == "Snow Duck"){
                    ShopScript.startSNDTimer = true;
                    print("SND Timer started");
                }
                if(newObject.tag == "Shield Duck"){
                    ShopScript.startSHDTimer = true;
                    print("SHD Timer started");
                }
                tileTarget.setTaken(true);
                tileTarget = null;
                shopActive = false;
            }
        }

        if(removeDefense){
            //HIGHLIGHT SQUARES
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit) && hit.transform.tag == "Tile" && hit.collider.transform.gameObject.GetComponent<TileScript>().getTaken()){

                hit.collider.transform.gameObject.GetComponent<TileScript>().setColor(Color.blue * 2);
            }
            if(hit.transform.gameObject.layer == 6){
                for(int i = 0; i< tiles.Length; i++){
                     if (hit.transform.position.x == tiles[i].transform.position.x && hit.transform.position.z == tiles[i].transform.position.z){
                         tiles[i].GetComponent<TileScript>().setColor(Color.blue * 2);
                         break;
                     }
                 }
            }
            if (Input.GetMouseButtonDown(0))
            {
                ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform != null && hit.transform.tag == "Tile" && hit.collider.transform.gameObject.GetComponent<TileScript>().getTaken())
                    {
                        for(int i = 0; i< ducks.Count; i++){
                            if (hit.transform.position.x == ducks[i].transform.position.x && hit.transform.position.z == ducks[i].transform.position.z){
                                Destroy(ducks[i]);
                                ducks.RemoveAt(i);
                                hit.transform.gameObject.GetComponent<TileScript>().setTaken(false);
                                removeDefense = false;
                                break;
                            }
                        }

                    }
                    if(hit.transform.gameObject.layer == 6){
                        Destroy(hit.transform.gameObject);
                        ducks.Remove(hit.transform.gameObject);
                        for(int i = 0; i< tiles.Length; i++){
                             if (hit.transform.position.x == tiles[i].transform.position.x && hit.transform.position.z == tiles[i].transform.position.z){
                                 tiles[i].GetComponent<TileScript>().setTaken(false);
                                 break;
                             }
                         }
                        removeDefense = false;
                    }
                }
            }
        }
    }

    public void deadDuck(DuckUnit duck, float x, float z)
    {
        List<SlimeUnit> attackers = duck.getAttackers();
        for (int i = 0; i < tiles.Length; i++)
        {
            if (x == tiles[i].transform.position.x && z == tiles[i].transform.position.z)
            {
                tiles[i].GetComponent<TileScript>().setTaken(false);
                break;
            }
        }
        for (int i = 0; i < ducks.Count; i++)
        {
            if (x == ducks[i].transform.position.x && z == ducks[i].transform.position.z)
            {
                Destroy(ducks[i]);
                for (int j = 0; j < attackers.Count; j++)
                {
                    print(attackers[j]);
                    attackers[j].defeatedDuck();
                }
                ducks.RemoveAt(i);
                break;
            }
        }
    }

     void setStart(TileScript start){
         this.start = start;
     }

     void setEnd(TileScript end){
         this.end = end;
     }

    List<TileScript> tileQueue = new List<TileScript>();

    public void computerPath(TileScript start, TileScript end)
    {
        //clear all nodes from past comuting
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].clear();
        }

        TileScript current;

        //start this dikjkstra
        start.setDistance(0);
        tileQueue.Clear();
        tileQueue.Add(start);

        while (tileQueue.Count > 0)
        {
            //find least tile
            int smallestIndex = 0;
            for (int i = 1; i < tileQueue.Count; i++)
            {
                if (tileQueue[i].getDistance() < tileQueue[smallestIndex].getDistance())
                {
                    smallestIndex = i;
                }
            }

            current = tileQueue[smallestIndex];
            tileQueue.RemoveAt(smallestIndex);

            current.setVisited(true);

            if (current == end)
            {
                break;
            }

            for (int i = 0; i < current.getNeighbors().Count; i++)
            {
                if (!current.getNeighbors()[i].getVisited())
                {
                    //not previously seen
                    if (current.getNeighbors()[i].getDistance() == float.MaxValue)
                    {
                        tileQueue.Add(current.getNeighbors()[i]);
                    }

                    float discreteDistance = current.getDistance() + 2;
                    if (current.getNeighbors()[i].getDistance() > discreteDistance)
                    {
                        current.getNeighbors()[i].setDistance(discreteDistance);
                        current.getNeighbors()[i].setBackPointer(current);
                    }
                }
            }
        }

        temp.Clear();
        path.Clear();
        current = end;
        while (current != start && current != null)
        {
            //current is the path from each node starting from the back to the front
            temp.Add(current);
            current = current.getBackPointer();
        }
        temp.Add(start);

        for (int i=temp.Count-1; i>=0; i--)
        {
            temp[i].setColor(Color.green * 3);
            path.Add(temp[i]);
        }
    }

    public TileScript[] getTiles(){
        return tiles;
    }
    public List<TileScript> getPath(){
        return path;
    }
}
