using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  public GameObject player;
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
    }

    public void OnTriggerEnter2D(Collider2D collision){
      collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, 1.5f * Time.deltaTime);
      Debug.Log("gotcha!");
    }

    // private void MoveFood(Collider2D foodObj){
    //   if(active == true){
    //     foodObj.transform.position = Vector2.MoveTowards(foodObj.transform.position, transform.position, 1.5f * Time.deltaTime);
    //     Debug.Log("gotcha!");
    //   }
    // }
}
