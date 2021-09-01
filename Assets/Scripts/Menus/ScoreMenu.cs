using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMenu : MonoBehaviour
{
    public TextMeshProUGUI[] texts = new TextMeshProUGUI[0];
    void Start()
    {
        UpdateScores();
    }

    void Update()
    {
        
    }

    public void UpdateScores() {
        PlayerScore.LoadScores();
        var scores = PlayerScore.GetScores();
        var players = PlayerScore.getPlayers();

        for (var i = 0; i < scores.Length; i++) {
            texts[i].text = players[i] + " - " + scores[i] + "P";
        }
    }
}
