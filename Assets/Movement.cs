using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

  public GameObject desk;
  public GameObject boss;
  public GameObject water;
  private float speed = 1.5f;
  private float place_num;

    // Start is called before the first frame update
    void Start()
    {
      place_num = Random.Range(1, 3);
      Debug.Log(place_num);
    }

    // Update is called once per frame
    void Update()
    {
      //get mouse Position
      Vector3 mousePos = Input.mousePosition;
      Vector3 mouse = Camera.main.ScreenToWorldPoint(mousePos);
      //Rotates the player to face the mouse
      transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg - 90);
      //consults random number to see where the player is moving too
      if(place_num == 1){
        //Moves the player towards the place of interest
        transform.position = Vector2.MoveTowards(transform.position, desk.transform.position, speed * Time.deltaTime);
      } else if (place_num == 2){
        transform.position = Vector2.MoveTowards(transform.position, boss.transform.position, speed * Time.deltaTime);
      } else if (place_num == 3){
        transform.position = Vector2.MoveTowards(transform.position, water.transform.position, speed * Time.deltaTime);
      }

    }
}
