using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public Button playButton;
    public AudioSource soundButtonHover;
    public AudioSource soundButtonClick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    public void playGame()
    {
        soundButtonClick.Play();
        SceneManager.LoadSceneAsync("Scenes/HungryHustler", LoadSceneMode.Single);
    }

    public void hoverButton()
    {
        soundButtonHover.Play();
        Debug.Log("hover");
    }
}
