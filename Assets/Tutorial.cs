using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
  //Tutorial assets
  public GameObject pickupZone;
  public GameObject coworkerL;
  public GameObject coworkerR;
  public GameObject food;
  //editable text
  public TMP_Text topTxt;
  public TMP_Text bottomTxt;
  //variables
  private int tutSection = 0;
  private string moveDirection = "first";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(tutSection >= 3){
          MovePlayer();
        }
        if(Input.GetKeyDown("space")){
          tutSection += 1;
        }
        switch(tutSection){
          case 1:
            topTxt.text = "You are this little fellow, Jeffrey! You have a lot to do today so you have no time to stop and eat.";
            bottomTxt.text = "However your energy will go down as you work so grab a lot snacks to fill it up again!";
            food.SetActive(true);
            break;
          case 2:
            topTxt.text = "This is your pick up zone! As Jeffrey bounces around the screen, it will stay rotated towards your mouse";
            bottomTxt.text = "When you hold down the spacebar any food item in it will be sucked towards you, but be careful! You have limited stamina so don’t hold it for too long";
            pickupZone.SetActive(true);
            break;
          case 3:
            topTxt.text = "Jeffery is swamped at work so he won't stop bouncing around while you play!";
            bottomTxt.text = "The text at the top of your screen will show you where he's going next, so pay close attention to see what snacks you can grab";
            coworkerL.SetActive(true);
            coworkerR.SetActive(true);
            break;
          case 4:
            topTxt.text = "Keep Jeffery going for as long as you can by colecting the food around you";
            bottomTxt.text = "On top of refilling energy, each food item is worth 1 point so go for the highest score you can get!";
            break;
          case 5:
            topTxt.text = "Thats all you need to know to survive the work day! Good luck hard worker!";
            bottomTxt.text = "Click spacebar to start the game";
            break;
        }
    }

    public void MovePlayer(){

      if(transform.position == coworkerL.transform.position){
        moveDirection = "right";
      } else if(transform.position == coworkerR.transform.position){
        moveDirection = "left";
      }

      switch(moveDirection){
        case "first":
          transform.position = Vector2.MoveTowards(transform.position, coworkerR.transform.position, 3.0f * Time.deltaTime);
          break;
        case "left":
          transform.position = Vector2.MoveTowards(transform.position, coworkerL.transform.position, 3.0f * Time.deltaTime);
          break;
        case "right":
          transform.position = Vector2.MoveTowards(transform.position, coworkerR.transform.position, 3.0f * Time.deltaTime);
          break;
      }
    }
}
