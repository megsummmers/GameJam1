using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class food : MonoBehaviour
{

    public float hungerRestored = 0.5f;
    public float direction = 0;
    public Sprite spriteFood;


    void Awake()
    {
        // set the sprite based on the random choice
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if touch walls, bounce

    }
    private void OnCollisionEnter(Collision collision)
    {
        // if touch player destroy it
        if (collision.gameObject.tag == "player")
        {
            RemoveFood();
        }
    }
    public void RemoveFood()
    {
        Destroy(this.gameObject);
    }
}
