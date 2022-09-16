using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScreen : MonoBehaviour
{
    public Text endingText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        endingText.text = "You Got: " + gameManager.playerScore + " Points!";
    }

    public void end()
    {
        Debug.Log("end");
        Application.Quit();
    }
}
