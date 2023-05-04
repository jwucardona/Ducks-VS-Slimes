using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ShopScript : MonoBehaviour
{
    private float drMoodTimer = 0;
    public GameObject speechBubble;
    public GameObject drMood;
    public TMP_Text drMoodText;

    public TMP_Text sunCounter;
    public GameObject BSPanel;
    public GameObject BDPanel;
    public GameObject SHDPanel;
    public GameObject BBPanel;
    public GameObject SNDPanel;
    public GameObject BRPanel;
    public GameObject infoPanel;
    public GameObject infoExitButton;
    public GameObject infoExitButtonBG;

    public GameObject BSFrame;
    public GameObject BDFrame;
    public GameObject SHDFrame;
    public GameObject BBFrame;
    public GameObject SNDFrame;
    public GameObject BRFrame;
    public GameObject shovelFrame;

    public GameObject blackoutPanel;

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
        drMoodTimer = 0;
        speechBubble.SetActive(true);
        drMood.SetActive(true);

        infoPanel.SetActive(false);
        infoExitButton.SetActive(false);
        infoExitButtonBG.SetActive(false);
        blackoutPanel.SetActive(false);
        SpawnCurrency.money = 100;



    }

    // Update is called once per frame
    void Update()
    {
        if(drMoodTimer <= 3){
        drMoodTimer += Time.deltaTime;
        }
        if(drMoodTimer > 3){
            speechBubble.SetActive(false);
            drMood.SetActive(false);
            drMoodText.text = " ";
        }
        sunCounter.text = SpawnCurrency.money.ToString();

        BSFrame.SetActive(false);
        BDFrame.SetActive(false);
        SHDFrame.SetActive(false);
        BBFrame.SetActive(false);
        SNDFrame.SetActive(false);
        BRFrame.SetActive(false);
        shovelFrame.SetActive(false);

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
        if(GameControllerScript.removeDefense){
            shovelFrame.SetActive(true);

        }else if(GameControllerScript.shopActive){

            if(currDefense == bubbleShooter){
                BSPanel.SetActive(false);
                BSFrame.SetActive(true);
            }
            if(currDefense == bubbleDuck){
                BDPanel.SetActive(false);
                BDFrame.SetActive(true);
            }
            if(currDefense == bubbleRepeater){
                BRPanel.SetActive(false);
                BRFrame.SetActive(true);
            }
            if(currDefense == bubbleBomb){
                BBPanel.SetActive(false);
                BBFrame.SetActive(true);
            }
            if(currDefense == snowDuck){
                SNDPanel.SetActive(false);
                SNDFrame.SetActive(true);
            }
            if(currDefense == shieldDuck){
                SHDPanel.SetActive(false);
                SHDFrame.SetActive(true);
            }
        }else{
            if(checkBSTimer()){
                if(SpawnCurrency.money >= 100){
                    BSPanel.SetActive(false);
                }
            }
            if(checkBDTimer()){
                if(SpawnCurrency.money >= 50){
                    BDPanel.SetActive(false);
                }
            }
            if(checkSHDTimer()){
                if(SpawnCurrency.money >= 50){
                    SHDPanel.SetActive(false);
                }
            }
            if(checkBBTimer()){
                if(SpawnCurrency.money >= 150){
                    BBPanel.SetActive(false);
                }
            }
            if(checkSNDTimer()){
                if(SpawnCurrency.money >= 175){
                    SNDPanel.SetActive(false);
                }
            }
            if(checkBRTimer()){
                if(SpawnCurrency.money >= 200){
                    BRPanel.SetActive(false);
                }
            }
        }
    }



    public static GameObject getCurrDefense(){
        return currDefense;
    }

    public void placeBubbleShooter(){
        GameControllerScript.shopActive = true;
        currDefense = bubbleShooter;
        SpawnCurrency.money = SpawnCurrency.money - 100;
    }
    public void placeBubbleDuck(){
        GameControllerScript.shopActive = true;
        currDefense = bubbleDuck;
        SpawnCurrency.money = SpawnCurrency.money - 50;
    }
    public void placeBubbleBomb(){
        GameControllerScript.shopActive = true;
        currDefense = bubbleBomb;
        SpawnCurrency.money = SpawnCurrency.money - 150;
    }
    public void placeShieldDuck(){
        GameControllerScript.shopActive = true;
        currDefense = shieldDuck;
        SpawnCurrency.money = SpawnCurrency.money - 50;
    }
    public void placeSnowDuck(){
        GameControllerScript.shopActive = true;
        currDefense = snowDuck;
        SpawnCurrency.money = SpawnCurrency.money - 175;
    }
    public void placeBubbleRepeater(){
        GameControllerScript.shopActive = true;
        currDefense = bubbleRepeater;
        SpawnCurrency.money = SpawnCurrency.money - 200;
    }

    public void removeDuck(){
        if(GameControllerScript.ducks.Count != 0){
            GameControllerScript.removeDefense = true;
        }
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

    public void exitGame(){
        Application.Quit();
    }

    public void infoScreen(){
        infoPanel.SetActive(true);
        infoExitButton.SetActive(true);
        infoExitButtonBG.SetActive(true);
        blackoutPanel.SetActive(true);

    }
    public void exitInfoScreen(){
        infoPanel.SetActive(false);
        infoExitButton.SetActive(false);
        infoExitButtonBG.SetActive(false);
        blackoutPanel.SetActive(false);
    }
}
