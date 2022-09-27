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
    public GameObject reception;
    public GameObject couch;
    public GameObject foodSpawnArea;

    private float speed = 3.0f;
    private float place_num;
    private float timeLeft = 30.0f;
    private int displayTime = 30;
    private bool gameOn = true;

    // levels
    public static int currentLevel = 1;

    // player stats
    public static float playerHunger = 15.0f;
    public static float playerHungerLimit = 10.0f;
    public static int playerScore = 0;

    public static float foodSpawnTimer = 6.0f;
    public static float foodSpawnFrequency = 6.0f;

    public static float foodWorth = 4.0f;

    // arrays of game objects
    public GameObject[] foodList;
    public GameObject[] obstaclesList;
    public GameObject[] locationsList;
    public GameObject[] coworkersList;

    // UI elements
    public TMP_Text clock;
    public TMP_Text textScore;
    public TMP_Text textLocation;
    public Canvas canvasPlayer;
    public GameObject spritePlayer;
    public Slider sliderHunger;

    // the borders of the screen
    public float screenLeft;
    public float screenRight;
    public float screenTop;
    public float screenBottom;

    // sounds
     public AudioSource soundBounce;
     public AudioSource soundEat;
     public AudioSource soundMove;
     public AudioSource soundObstacle;
     public AudioSource soundMusic;

    // Start is called before the first frame update
    void Start()
    {
      place_num = Random.Range(1, 8);
      sliderHunger.value = playerHunger;
      playerHunger = playerHungerLimit;
      sliderHunger.maxValue = playerHungerLimit;
        Debug.Log("Screen Height : " + Screen.height);
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
        // change the hunger value by -5%
        playerHunger -= Time.deltaTime;
        sliderHunger.value = playerHunger;
        if (timeLeft < 0)
        {
            GameOver();
        }
        if (playerHunger <= 0)
        {
            GameOver();
        }
        //get mouse Position
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mousePos);
        //Rotates the player to face the mouse
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg - 90);
	      spritePlayer.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg - 90);
        //hunger bar
        canvasPlayer.transform.position = new Vector3(spritePlayer.transform.position.x, spritePlayer.transform.position.y + 0.7f, -1);
        canvasPlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
        //consults random number to see where the player is moving too
        switch(place_num)
        {
          case 1: //desk
          transform.position = Vector2.MoveTowards(transform.position, desk.transform.position, speed * Time.deltaTime);
          textLocation.text = "Next Task:\n\nVisit\nCo-workers";
          break;
          case 2: //boss
          transform.position = Vector2.MoveTowards(transform.position, boss.transform.position, speed * Time.deltaTime);
          textLocation.text = "Next Task:\n\nTalk to\nBoss";
          break;
          case 3: //water
          transform.position = Vector2.MoveTowards(transform.position, water.transform.position, speed * Time.deltaTime);
          textLocation.text = "Next Task:\n\nWater\nCooler";
          break;
          case 4: //printer
          transform.position = Vector2.MoveTowards(transform.position, printer.transform.position, speed * Time.deltaTime);
          textLocation.text = "Next Task:\n\nPrint\nstuff";
          break;
          case 5: //reception
          transform.position = Vector2.MoveTowards(transform.position, reception.transform.position, speed * Time.deltaTime);
          textLocation.text = "Next Task:\n\nVisit\nReception";
          break;
          case 6: //random place
          transform.position = Vector2.MoveTowards(transform.position, couch.transform.position, speed * Time.deltaTime);
          textLocation.text = "Next Task:\n\nSit on\nCouch";
          break;
        }
      }
    }

    // player collision
    public void OnTriggerEnter2D(Collider2D collision){
      if(collision.gameObject.tag == "place"){
        StartCoroutine(SwitchCoroutine());
      }
      if (collision.gameObject.tag == "obstacle")
      {
        soundObstacle.Play();
      }
        if (collision.gameObject.tag == "food"){
        //hide the food item
        collision.gameObject.SetActive(false);
        soundEat.Play();
        playerScore++;
        playerHunger += foodWorth;
        if(playerHunger > playerHungerLimit){
           playerHunger = playerHungerLimit;
        }
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
        soundBounce.Play();
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
