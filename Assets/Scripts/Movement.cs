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
  public TMP_Text endTxt;
  public TMP_Text scoreTxt;
  private TextMeshProUGUI setClock;
  private TextMeshProUGUI setEndTxt;
  private TextMeshProUGUI setScoreTxt;
  private float speed = 1.2f;
  private float place_num;
  private float timeLeft = 30;
  private float score = 0;
  private bool gameOn = true;

    // Start is called before the first frame update
    void Start()
    {
      place_num = Random.Range(1, 3);
      //set stuff to textMeshProUGUI
      setClock = clock.GetComponent<TextMeshProUGUI>();
      setEndTxt = endTxt.GetComponent<TextMeshProUGUI>();
      setScoreTxt = scoreTxt.GetComponent<TextMeshProUGUI>();
      //hide end text
      setEndTxt.enabled = false;
      setScoreTxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      //subtracts one every second
      timeLeft -= Time.deltaTime;
      //change clock text
      int time = Mathf.FloorToInt(timeLeft);
      setClock.text = time.ToString();
      if (timeLeft < 0 ){
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
        Debug.Log("here");
        StartCoroutine(SwitchCoroutine());
        // float currentNum = place_num;
        // place_num = Random.Range(1, 7);
        // while(place_num == currentNum){
        //   place_num = Random.Range(1, 7);
        // }
      }
      if(collision.gameObject.tag == "food"){
        Debug.Log("yum!");
        //hide the food item
        collision.gameObject.SetActive(false);
        score += 1;
      }
    }

    IEnumerator SwitchCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        float currentNum = place_num;
        place_num = Random.Range(1, 7);
        while(place_num == currentNum){
          place_num = Random.Range(1, 7);
        }
    }

    public void GameOver(){
      //stop player movement
      gameOn = false;
    }
  }
