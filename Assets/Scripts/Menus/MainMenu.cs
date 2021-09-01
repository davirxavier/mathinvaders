using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField input;
    public void StartGame() {
        if (input != null) {
            var name = input.text;
            if (name.Length > 3) {
                return;
            }
            ConstantValues.currentPlayerName = name;

            ConstantValues.currentLevel = 1;
            SceneManager.LoadScene(1);
        }
    }
    public void ExitGame() {
        Application.Quit();
    }
}
