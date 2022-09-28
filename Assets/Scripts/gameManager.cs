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
    public GameObject foodPrefab;
    public Camera mainCamera;

    private float speed = 3.0f;
    private float place_num;
    private bool gameOn = true;
    private bool foodSpawnDone = true;

    // levels
    public static int currentLevel = 1;

    // player stats
    public static float playerHunger = 15.0f;
    public static int playerHungerDisplay;
    public static float playerHungerLimit = 10.0f;
    public static int playerScore = 0;
    public static float playerStamina = 10.0f;
    public static float playerStaminaLimit = 10.0f;
    public static float playerStaminaRestore = 1.0f;

    public static float foodSpawnTimer = 6.0f;
    public static float foodSpawnFrequency = 6.0f;

    public static float foodWorth = 4.0f;

    public static Vector2 screenSize;

    // arrays of game objects
    //public GameObject[] foodList;
    //public GameObject[] obstaclesList;
    //public GameObject[] locationsList;
    //public GameObject[] coworkersList;

    // UI elements
    public TMP_Text textHunger;
    public TMP_Text textScore;
    public TMP_Text textLocation;
    public Canvas canvasPlayer;
    public GameObject spritePlayer;
    public Slider sliderStamina;

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
      place_num = Random.Range(1, 7);
      sliderStamina.value = playerStamina;
      playerHunger = playerHungerLimit;
      sliderStamina.maxValue = playerStaminaLimit;
      screenSize = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Fixed Update is called once per frame (better to use than Update)
    void FixedUpdate()
    {
      if(gameOn){
        // if the food just spawned, start the timer again
        if (foodSpawnDone == true)
        {
            foodSpawnDone = false;
            StartCoroutine(FoodSpawnTimerCode());
        }
        //subtracts one every second
        playerHunger -= Time.deltaTime;
        playerHungerDisplay = Mathf.RoundToInt(playerHunger);
        //change hunger text
        textHunger.text = "Hunger: " + playerHungerDisplay;
        textScore.text = "Score: " + playerScore;
        // if the stamina is not full, restore stamina
        if (playerStamina < playerStaminaLimit)
        {
           playerStamina += (playerStaminaRestore / 10);
        }
        if (playerStamina == 0)
        {
            FollowPlayer.audioPlay = false;
            FollowPlayer.magnet = false;
        }
        sliderStamina.value = playerStamina;
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

    IEnumerator FoodSpawnTimerCode()
    {
        foodSpawnTimer = foodSpawnFrequency;
        while (foodSpawnTimer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            foodSpawnTimer--;
        }
        Instantiate(foodPrefab, foodSpawnArea.transform.position, Quaternion.identity);
        foodSpawnDone = true;
    }

    IEnumerator SwitchCoroutine()
    {
        //Print the time of when the function is first called.

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
