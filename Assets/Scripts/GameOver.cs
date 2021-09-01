using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject playerMenu;
    public void OnGameOver() {
        PlayerScore.SaveScore(PlayerScore.GetCurrentPoints(), ConstantValues.currentPlayerName);

        if (gameOverMenu != null) {
            gameOverMenu.SetActive(true);
            var menuScript = gameOverMenu.GetComponent<GameOverMenu>();
            if (menuScript != null) {
                menuScript.SetPointText(PlayerScore.GetCurrentPoints());
            }
        }

        if (playerMenu != null) {
            playerMenu.SetActive(false);
        }
    }
}
