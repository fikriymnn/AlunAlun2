using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mianMenuUI : MonoBehaviour
{
    public GameObject tentang, panduan;
    public AudioSource klikSound;

    public void showTentang()
    {
        klikSound.Play();
        tentang.SetActive(true);
        panduan.SetActive(false);
    }

    public void hideTentang()
    {
        tentang.SetActive(false);
        panduan.SetActive(false);
    }

    public void showPanduan()
    {
        klikSound.Play();
        tentang.SetActive(false);
        panduan.SetActive(true);
    }

    public void hidePanduan()
    {
        tentang.SetActive(false);
        panduan.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
