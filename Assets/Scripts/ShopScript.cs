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

    public static bool startBSTimer = false;
    public static float BSTimer;
    public static bool startBDTimer = false;
    public static float BDTimer;
    public static bool startSHDTimer = false;
    public static float SHDTimer;
    public static bool startBBTimer = false;
    public static float BBTimer;
    public static bool startSNDTimer = false;
    public static float SNDTimer;
    public static bool startBRTimer = false;
    public static float BRTimer;


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

        if(startBSTimer){
            BSTimer += Time.deltaTime;
        }
        if(startBDTimer){
            BDTimer += Time.deltaTime;
        }
        if(startBBTimer){
            BBTimer += Time.deltaTime;
        }
        if(startBRTimer){
            BRTimer += Time.deltaTime;
        }
        if(startSHDTimer){
            SHDTimer += Time.deltaTime;
        }
        if(startSNDTimer){
            SNDTimer += Time.deltaTime;
        }

        if(checkBSTimer()){
            if(currencyClick.score >= 100){
                BSPanel.SetActive(false);
            }
        }
        if(checkBDTimer()){
            if(currencyClick.score >= 50){
                BDPanel.SetActive(false);
            }
        }
        if(checkSHDTimer()){
            if(currencyClick.score >= 50){
                SHDPanel.SetActive(false);
            }
        }
        if(checkBBTimer()){
            if(currencyClick.score >= 150){
                BBPanel.SetActive(false);
            }
        }
        if(checkSNDTimer()){
            if(currencyClick.score >= 175){
                SNDPanel.SetActive(false);
            }
        }
        if(checkBRTimer()){
            if(currencyClick.score >= 200){
                BRPanel.SetActive(false);
            }
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
    public void placeBubbleBomb(){
        GameControllerScript.shopActive = true;
        currDefense = bubbleBomb;
        print("bubbleBomb");
        currencyClick.score = currencyClick.score - 150;
    }
    public void placeShieldDuck(){
        GameControllerScript.shopActive = true;
        currDefense = shieldDuck;
        print("shieldDuck");
        currencyClick.score = currencyClick.score - 50;
    }
    public void placeSnowDuck(){
        GameControllerScript.shopActive = true;
        currDefense = snowDuck;
        print("snowDuck");
        currencyClick.score = currencyClick.score - 175;
    }
    public void placeBubbleRepeater(){
        GameControllerScript.shopActive = true;
        currDefense = bubbleRepeater;
        print("bubbleRepeater");
        currencyClick.score = currencyClick.score - 200;
    }
    public void removeDuck(){
        print("remove Duck");
        GameControllerScript.removeDefense = true;
    }

    public bool checkBSTimer(){
        if(!startBSTimer){
            return true;
        }
        if(startBSTimer){
            if(BSTimer >= 7.5f){
                BSTimer = 0;
                startBSTimer = false;
                return true;
            }
        }
        return false;
    }

    public bool checkBDTimer(){
        if(!startBDTimer){
            return true;
        }
        if(startBDTimer){
            if(BDTimer >= 7.5f){
                BDTimer = 0;
                startBDTimer = false;
                return true;
            }
        }
        return false;
    }
    public bool checkBBTimer(){
        if(!startBBTimer){
            return true;
        }
        if(startBBTimer){
            if(BBTimer >= 50f){
                BBTimer = 0;
                startBBTimer = false;
                return true;
            }
        }
        return false;
    }
    public bool checkSHDTimer(){
        if(!startSHDTimer){
            return true;
        }
        if(startSHDTimer){
            if(SHDTimer >= 30f){
                SHDTimer = 0;
                startSHDTimer = false;
                return true;
            }
        }
        return false;
    }
    public bool checkSNDTimer(){
        if(!startSNDTimer){
            return true;
        }
        if(startSNDTimer){
            if(SNDTimer >= 7.5f){
                SNDTimer = 0;
                startSNDTimer = false;
                return true;
            }
        }
        return false;
    }
    public bool checkBRTimer(){
        if(!startBRTimer){
            return true;
        }
        if(startBRTimer){
            if(BRTimer >= 7.5f){
                BRTimer = 0;
                startBRTimer = false;
                return true;
            }
        }
        return false;
    }
}
