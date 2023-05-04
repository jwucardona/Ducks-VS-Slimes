using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InstructionScript : MonoBehaviour
{
    public TMP_Text instructions;
    private int instructionCounter = -1;
    public GameObject infoScreen;
    public GameObject infoButton;
    public GameObject shop;
    public GameObject bucket;
    public GameObject waterDrop;

    // Start is called before the first frame update
    void Start()
    {
        instructionCounter = -1;
        instructions.text = "Hi, I'm Dr. Mood!";

        infoScreen.SetActive(false);
        infoButton.SetActive(false);
        shop.SetActive(false);
        bucket.SetActive(false);
        waterDrop.SetActive(false);

    }

    public void increaseCounter(){
        instructionCounter++;
    }

    // Update is called once per frame
    void Update()
    {

        if(instructionCounter == 12){
            SceneManager.LoadScene("main");
        }else if(instructionCounter == 11){
            instructions.text = "Good luck traveller!";
        }else if(instructionCounter ==10){
            instructions.text = "Some slimes are stronger and faster than others...";
        }else if(instructionCounter ==9){
            instructions.text = "But BEWARE!!!!!";
        }else if(instructionCounter ==8){
            instructions.text = "that you don't want anymore.";
        }else if(instructionCounter ==7){
            instructions.text = "Click on the bucket to remove ducks";
            infoScreen.SetActive(false);
            bucket.SetActive(true);
        }else if(instructionCounter == 6){
            instructions.text = "You can access this from the info button on top.";
            infoButton.SetActive(true);
        }else if(instructionCounter ==5){
            instructions.text = "This is a menu of all the different duck powers.";
            waterDrop.SetActive(false);
            infoScreen.SetActive(true);
        }else if(instructionCounter ==4){
            instructions.text = "Click on them to collect them.";
        }else if(instructionCounter ==3){
            instructions.text = "You can buy slimes using water drops. They look like this.";
            waterDrop.SetActive(true);
        }else if(instructionCounter ==2){
            instructions.text = "Buy slimes from the shop to attack slimes.";
            shop.SetActive(true);
        }else if(instructionCounter == 1){
            instructions.text = "But you, weary traveller, seem like you can help me out!";
        }else if(instructionCounter == 0){
            instructions.text = "Some devious slimes have seem overrun my precious duck pond D:";
        }


    }
}
