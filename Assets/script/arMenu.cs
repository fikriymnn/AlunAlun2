using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arMenu : MonoBehaviour
{
    public void sceneMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void scenePlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
