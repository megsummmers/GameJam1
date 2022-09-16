using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadKeep : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadSceneAsync("Scenes/TitleScreen", LoadSceneMode.Single);
    }
}
