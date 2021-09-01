using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI pointText;

    public void SetPointText(int points) {
        if (pointText != null) {
            pointText.text = points + "P";
        }
    }
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
}
