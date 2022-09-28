using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  public GameObject player;
  public List<GameObject> foodTouched = new List<GameObject>();

  public AudioSource soundSuction;

  static public bool magnet = false;
  static public bool audioPlay = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
      //get player Position
      Vector3 playerObj = player.transform.position;
      //move circle to player Position
      transform.position = new Vector3(playerObj.x, playerObj.y, playerObj.z);
        //get mouse Position
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mousePos);
        //Rotates the player to face the mouse
        // code from https://www.youtube.com/watch?v=mKLp-2iseDc
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg - 90);
        // if suck and has stamina, then any food in the area gets sucked towards the player
        if (Input.GetKey("space") && gameManager.playerStamina > 0){//move food
          gameManager.playerStamina -= Time.deltaTime * 20.0f;
          if(audioPlay && gameManager.playerStamina > 0){
            StartCoroutine(playSuctionSound());
          }
        }
      }

    public void OnTriggerEnter2D(Collider2D collision){
      //collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, 1.5f * Time.deltaTime);
      if (collision.gameObject.tag == "food") 
      {
        collision.gameObject.food.suckedIn = true;
      }
    }

    public void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "food") 
        {
        collision.gameObject.food.suckedIn = false;
        }
    }

    IEnumerator playSuctionSound()
    {
      soundSuction.Play();
      audioPlay = false;
      yield return new WaitForSeconds(soundSuction.clip.length);
      audioPlay = true;
    }
}
