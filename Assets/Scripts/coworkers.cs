using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coworkers : MonoBehaviour
{
    public float minimum;
    public float maximum;
    public float t = 0.0f;
    private string tag;
    // Start is called before the first frame update
    void Start()
    {
      tag = gameObject.tag;
      Debug.Log(tag);
      if(tag == "Horizontal"){
        minimum = transform.position.x - 0.1F;
        maximum = transform.position.x + 0.1F;
      } else if(tag == "Vertical"){
        minimum = transform.position.y - 0.1F;
        maximum = transform.position.y + 0.1F;
      }

    }

    // Update is called once per frame
    void Update()
    {
      // animate the position of the game object...
      if(tag == "Horizontal"){
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), transform.position.y, 0);
      } else if(tag == "Vertical"){
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(minimum, maximum, t), 0);
      }

      // .. and increase the t interpolater
      t += 0.5f * Time.deltaTime;

      // now check if the interpolator has reached 1.0
      // and swap maximum and minimum so game object moves
      // in the opposite direction.
      if (t > 1.0f){
        float temp = maximum;
        maximum = minimum;
        minimum = temp;
        t = 0.0f;
      }
    }
}
