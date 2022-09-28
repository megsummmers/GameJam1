using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class food : MonoBehaviour
{

    public float speed = 2.5f;
    public Sprite spriteFood;
    public Sprite[] spriteFoodList;
    public GameObject player;
    public GameObject movementTarget;


    void Awake()
    {
        // set the sprite based on the random choice
        spriteFood = spriteFoodList[Random.Range(0, spriteFoodList.Length)];
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("spritePlayer");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate
        // if touch walls, bounce

    }
    private void OnCollisionEnter(Collision collision)
    {
        // if touch player destroy it
        if (collision.gameObject.tag == "player")
        {
            RemoveFood();
        }
        if (collision.gameObject.tag == "suction" && FollowPlayer.magnet == true)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    public void RemoveFood()
    {
        Destroy(this.gameObject);
    }
}
