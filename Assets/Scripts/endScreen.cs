using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScreen : MonoBehaviour
{
    public Text endingText;
    public AudioSource soundDefeat;
    public AudioSource soundVictory;
    private GameObject losePanel;

    // Start is called before the first frame update
    void Start()
    {
      losePanel =  GameObject.Find("Panel_lose");
      if(gameManager.playerScore >= 5){
        losePanel.SetActive(false);
        soundVictory.Play();
      } else if (gameManager.playerScore < 5) {
        soundDefeat.Play();
      }
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
