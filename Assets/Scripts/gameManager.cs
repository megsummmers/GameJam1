using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject desk;
    public GameObject boss;
    public GameObject water;
    public GameObject printer;
    public GameObject bathroom;
    public GameObject random;
    public GameObject desk_2;
    public GameObject bathroom_2;
    public GameObject bathroom_3;
    public GameObject random_2;

    private float speed = 3.0f;
    private float place_num;
    private float timeLeft = 30.0f;
    private int displayTime = 30;
    private bool gameOn = true;

    // levels
    public static int currentLevel = 1;

    // player stats
    public static int playerHunger = 100;
    public static int playerScore = 0;

    // arrays of game objects
    public GameObject[] foodList;
    public GameObject[] obstaclesList;
    public GameObject[] locationsList;
    public GameObject[] coworkersList;

    // UI elements
    public TMP_Text clock;
    public TMP_Text textScore;

    // sounds
     public AudioSource soundBounce;
     public AudioSource soundEat;
     public AudioSource soundMove;
     public AudioSource soundObstacle;

    // Start is called before the first frame update
    void Start()
    {
      place_num = Random.Range(1, 3);
    }

    // Fixed Update is called once per frame (better to use than Update)
    void FixedUpdate()
    {
      if(gameOn){
        //subtracts one every second
        timeLeft -= Time.deltaTime;
        displayTime = Mathf.RoundToInt(timeLeft);
        //change clock text
        clock.text = "Time Left: " + displayTime;
        textScore.text = "Score: " + playerScore;
        if (timeLeft < 0)
        {
            GameOver();
        }
        //get mouse Position
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mousePos);
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

    // player collision
    public void OnTriggerEnter2D(Collider2D collision){
      if(collision.gameObject.tag == "place"){
        Debug.Log("here");
        StartCoroutine(SwitchCoroutine());
        // float currentNum = place_num;
        // place_num = Random.Range(1, 7);
        // while(place_num == currentNum){
        //   place_num = Random.Range(1, 7);
        // }
      }
      if(collision.gameObject.tag == "food"){
        //hide the food item
        collision.gameObject.SetActive(false);
        playerScore += 1;
      }
    }

    IEnumerator SwitchCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
        float currentNum = place_num;
        place_num = Random.Range(1, 7);
        while(place_num == currentNum){
          place_num = Random.Range(1, 7);
        }
    }

    // end the game
    public void GameOver(){
      gameOn = false;
      transform.position = new Vector3(0, 0, 0);
      SceneManager.LoadSceneAsync("Scenes/end", LoadSceneMode.Single);

    }

    // exit the game
    public void end()
    {
        Application.Quit();
    }
}
