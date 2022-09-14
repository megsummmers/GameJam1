using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
  public GameObject desk;
  public GameObject boss;
  public GameObject water;
  public GameObject printer;
  public GameObject bathroom;
  public GameObject random;
  public TMP_Text clock;
  public GameObject gameOverTxt;
  private float speed = 1.2f;
  private float place_num;
  private float timeLeft = 30;
  private bool gameOn = true;

    // Start is called before the first frame update
    void Start()
    {
      place_num = Random.Range(1, 3);
      Debug.Log(place_num);
    }

    // Update is called once per frame
    void Update()
    {
      //subtracts one every second
      timeLeft -= Time.deltaTime;
      //change clock text
      clock.SetText($"{timeLeft}");
      if ( timeLeft < 0 ){
        GameOver();
      }
      //get mouse Position
      Vector3 mousePos = Input.mousePosition;
      Vector3 mouse = Camera.main.ScreenToWorldPoint(mousePos);
      if(gameOn){
        //Rotates the player to face the mouse
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg - 90);
        //consults random number to see where the player is moving too
        switch(place_num)
        {
          case 1: //desk
          transform.position = Vector2.MoveTowards(transform.position, desk.transform.position, speed * Time.deltaTime);
          break;
          case 2: //boss
          transform.position = Vector2.MoveTowards(transform.position, boss.transform.position, speed * Time.deltaTime);
          break;
          case 3: //water
          transform.position = Vector2.MoveTowards(transform.position, water.transform.position, speed * Time.deltaTime);
          break;
          case 4: //printer
          transform.position = Vector2.MoveTowards(transform.position, printer.transform.position, speed * Time.deltaTime);
          break;
          case 5: //bathroom
          transform.position = Vector2.MoveTowards(transform.position, bathroom.transform.position, speed * Time.deltaTime);
          break;
          case 6: //random place
          transform.position = Vector2.MoveTowards(transform.position, random.transform.position, speed * Time.deltaTime);
          break;
        }
      }
    }

    public void OnTriggerEnter2D(Collider2D collision){
      float currentNum = place_num;
      if(collision.gameObject.tag == "place"){
        place_num = Random.Range(1, 7);
        while(place_num == currentNum){
          place_num = Random.Range(1, 7);
        }
      }
      if(collision.gameObject.tag == "food"){
        Debug.Log("yum!");
        //hide the food item
        collision.gameObject.SetActive(false);
      }
    }

    public void GameOver(){
      gameOn = false;
      transform.position = new Vector3(0, 0, 0);

    }
}
