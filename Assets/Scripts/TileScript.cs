using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public List<TileScript> neighbors = new List<TileScript>();
    float distance;
    TileScript backPointer;
    bool hasVisited;
    bool taken = false;
    [SerializeField] GameObject lilyPad;
    [SerializeField] GameObject flower;

    private GameControllerScript theGameController = GameControllerScript.getInstance();

    public GameObject[] borders;

    public List<TileScript> getNeighbors()
    {
        return neighbors;
    }

    public void clear()
    {
        distance = float.MaxValue;
        hasVisited = false;
        backPointer = null;

        borders[0].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.black);
        borders[1].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.black);
        borders[2].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.black);
        borders[3].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.black);
    }

    public void setDistance(float distance_in)
    {
        distance = distance_in;
    }

    public float getDistance()
    {
        return distance;
    }
    public void setTaken(bool taken_in){
        taken = taken_in;
    }
    public bool getTaken(){
        return taken;
    }

    public void setVisited(bool visited_in)
    {
        hasVisited = visited_in;
    }

    public bool getVisited()
    {
        return hasVisited;
    }

    public void setBackPointer(TileScript backPlace)
    {
        backPointer = backPlace;
    }

    public TileScript getBackPointer()
    {
        return backPointer;
    }

    public void setColor(Color theColor)
    {
        borders[0].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", theColor);
        borders[1].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", theColor);
        borders[2].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", theColor);
        borders[3].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", theColor);
    }
   
    void Start(){
        // rotates the lily pad at a random angle on its y axis
        lilyPad.transform.Rotate(0, Random.Range(0, 360), 0);
        // sets the visibility of the lily pad flower to false by random chance and also rotates it at a random angle on its y axis
        if (Random.Range(0, 2) == 1)
        {
            flower.SetActive(true);
            flower.transform.Rotate(0, Random.Range(0, 360), 0);
        }
        else
        {
            flower.SetActive(false);
        }
    }
    private void OnMouseEnter(){
        //theGameController.setEnd();
    }
}
