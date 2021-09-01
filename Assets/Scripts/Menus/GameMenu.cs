using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject menu;   
    public GameObject[] pausedTexts = new GameObject[0];
    void Start()
    {
        paused = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (menu.activeSelf) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Pause() {
        pausedTexts = GameObject.FindGameObjectsWithTag("MathText");
        foreach (var text in pausedTexts) {
            text.SetActive(false);
        }

        paused = true;
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        foreach (var text in pausedTexts) {
            text.SetActive(true);
        }
        pausedTexts = new GameObject[0];

        paused = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit() {
        Application.Quit();
    }
}
