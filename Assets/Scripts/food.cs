using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class food : MonoBehaviour
{

    public float speed = 2.5f;
    public Sprite spriteFood;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteFoodList;
    public GameObject player;
    public GameObject movementTarget;
    public Vector2 direction;
    private bool suckedIn = false;


    void Awake()
    {
        // set the sprite based on the random choice
        spriteFood = spriteFoodList[Random.Range(0, spriteFoodList.Length)];
     //   transform.position = new Vector3(0, 0, 0);
        spriteRenderer.sprite = spriteFood;
        direction = new Vector2(Random.Range(Random.Range(-0.04f, -0.02f), Random.Range(0.02f, 0.04f)), Random.Range(Random.Range(-0.04f, -0.02f), Random.Range(0.02f, 0.04f)));
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("spritePlayer");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (suckedIn == false) 
        {
          transform.Translate(direction.x * speed, direction.y * speed, 0.0f);
        } else if (suckedIn == true) 
        {
          this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        // if touch walls, bounce
        if (transform.position.x >= 8.5f)
        {
            direction.x *= -1;
        }
        if (transform.position.x <= -8.5f)
        {
            direction.x *= -1;
        }
        if (transform.position.y >= 4.5f)
        {
            direction.y *= -1;
        }
        if (transform.position.y <= -4.5f)
        {
            direction.y *= -1;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        // if touch player destroy it
        if (collision.gameObject == player)
        {
            RemoveFood();
        }
        if (collision.gameObject.tag == "suction" && FollowPlayer.magnet == true)
        {
            suckedIn = true;
            Debug.Log("suck");
        }
    }
    public void RemoveFood()
    {
        Destroy(this.gameObject);
    }
}
