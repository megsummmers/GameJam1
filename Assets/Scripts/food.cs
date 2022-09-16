using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class food : MonoBehaviour
{

    public float hungerRestored = 0.5f;
    public AudioClip eat;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if it rotated too much, destroy it
        if (this.transform.rotation.x >= 60 || this.transform.rotation.y >= 60 || this.transform.rotation.z >= 60)
        {
            Debug.Log("rotate");
            RemoveFood();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // if touch borders destroy it
        if (collision.gameObject.tag == "player")
        {
            RemoveFood();
        }
    }
    public void RemoveFood()
    {
        AudioSource.PlayClipAtPoint(eat, gameObject.transform.position, 0.5f);
        Destroy(this.gameObject);
    }
}
