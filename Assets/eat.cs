using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eat : MonoBehaviour
{
  public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //get player Position
      Vector3 playerObj = player.transform.position;
      Vector3 playerPos = Camera.main.ScreenToWorldPoint(playerObj);
      //move circle to player Position
      transform.position = new Vector3(playerObj.x, playerObj.y + 1, playerObj.z);
      //get mouse Position
      Vector3 mouse = Input.mousePosition;
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouse);
      //Rotates the player to face the mouse
      transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg);
    }

    public void OnTriggerEnter2D(Collider2D collision){
      if(collision.gameObject.tag == "food"){
        Debug.Log("gotcha!");
      }
    }
}
