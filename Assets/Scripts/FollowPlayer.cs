using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  public GameObject player;
  public GameObject Chocolate;
  public GameObject Donut;
  public GameObject Energydrink;
  public GameObject Soda;

  public AudioSource soundSuction;

  private bool magnet = false;
  private string food_active;
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
      transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg - 90);

      if(Input.GetKey("space")){//move food
        // soundSuction.Play();
        switch(food_active)
        {
          case "Chocolate": //desk
          Chocolate.transform.position = Vector2.MoveTowards(Chocolate.transform.position, player.transform.position, 1.5f * Time.deltaTime);
          break;
          case "Donut": //boss
          Donut.transform.position = Vector2.MoveTowards(Donut.transform.position, player.transform.position, 1.5f * Time.deltaTime);
          break;
          case "Energydrink": //water
          Energydrink.transform.position = Vector2.MoveTowards(Energydrink.transform.position, player.transform.position, 1.5f * Time.deltaTime);
          break;
          case "Soda": //printer
          Soda.transform.position = Vector2.MoveTowards(Soda.transform.position, player.transform.position, 1.5f * Time.deltaTime);
          break;
        }
      }
    }

    public void OnTriggerEnter2D(Collider2D collision){
      //collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, 1.5f * Time.deltaTime);
      magnet = true;
      food_active = collision.gameObject.name;
    }

    public void OnTriggerExit2D(Collider2D collision){
      Debug.Log("no more");
      magnet = false;
      food_active = "";
    }

    // private void MoveFood(Collider2D foodObj){
    //   if(active == true){
    //     foodObj.transform.position = Vector2.MoveTowards(foodObj.transform.position, transform.position, 1.5f * Time.deltaTime);
    //     Debug.Log("gotcha!");
    //   }
    // }
}
