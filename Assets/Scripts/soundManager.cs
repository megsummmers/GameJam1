using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    static public AudioSource soundBounce;
    static public AudioSource soundEat;
    static public AudioSource soundMove;
    static public AudioSource soundObstacle;
    static public AudioSource soundButtonClick;
    static public AudioSource soundButtonHover;

    static public void playSoundBounce()
    {
        soundBounce.Play();
    }
    static public void playSoundEat()
    {
        soundEat.Play();
    }
    static public void playSoundMove()
    {
        soundMove.Play();
    }
    static public void playSoundObstacle()
    {
        soundObstacle.Play();
    }
    static public void playSoundButtonClick()
    {
        soundButtonClick.Play();
    }
    static public void playSoundButtonHover()
    {
        soundButtonHover.Play();
    }
}