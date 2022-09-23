using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScreen : MonoBehaviour
{
    public Text endingText;
    public AudioSource soundDefeat;

    // Start is called before the first frame update
    void Start()
    {
        soundDefeat.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        endingText.text = "You Got: " + gameManager.playerScore + " Point(s)!";
    }

    public void end()
    {
        Debug.Log("end");
        Application.Quit();
    }
}
