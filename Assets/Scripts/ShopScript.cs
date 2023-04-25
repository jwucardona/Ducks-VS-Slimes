using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScript : MonoBehaviour
{
    public TMP_Text sunCounter;
    public GameObject BSPanel;
    public GameObject BDPanel;
    public GameObject SHDPanel;
    public GameObject BBPanel;
    public GameObject SNDPanel;
    public GameObject BRPanel;

    private static GameObject currDefense;
    public GameObject bubbleShooter;
    public GameObject bubbleDuck;
    public GameObject bubbleBomb;
    public GameObject shieldDuck;
    public GameObject snowDuck;
    public GameObject bubbleRepeater;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sunCounter.text = currencyClick.score.ToString();

        BSPanel.SetActive(true);
        BDPanel.SetActive(true);
        BBPanel.SetActive(true);
        SHDPanel.SetActive(true);
        SNDPanel.SetActive(true);
        BRPanel.SetActive(true);

        if(currencyClick.score >= 100){
            BSPanel.SetActive(false);
        }
        if(currencyClick.score >= 50){
            BDPanel.SetActive(false);
            SHDPanel.SetActive(false);
        }
        if(currencyClick.score >= 150){
            BBPanel.SetActive(false);
        }
        if(currencyClick.score >= 175){
            SNDPanel.SetActive(false);
        }
        if(currencyClick.score >= 200){
            BRPanel.SetActive(false);
        }
    }

    public static GameObject getCurrDefense(){
        return currDefense;
    }

    public void placeBubbleShooter(){
        GameControllerScript.shopActive = true;
        currDefense = bubbleShooter;
        print("bubbleShooter");
        currencyClick.score = currencyClick.score - 100;
    }
    public void placeBubbleDuck(){
        GameControllerScript.shopActive = true;
        currDefense = bubbleDuck;
        print("bubbleDuck");
        currencyClick.score = currencyClick.score - 50;
    }
    public void removeDuck(){
        print("remove Duck");
        GameControllerScript.removeDefense = true;
    }
}
