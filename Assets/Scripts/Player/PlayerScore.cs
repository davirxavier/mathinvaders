using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class PlayerScore
{
    private static int[] highscores;
    private static string[] players;
    private static string highscorekey = "highscore_";
    private static string playernamekey = "player_";
    private static TextMeshProUGUI text;
    private static int currentPoints = 0;
    public static void AddPoints(int points) {
        currentPoints += points;
        if (text == null) {
            text = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        }

        if (text != null) {
            text.text = currentPoints + "P";
        }
    }

    public static int GetCurrentPoints() {
        return currentPoints;
    }

    public static int[] LoadScores() {
        var podium = ConstantValues.podiumCount;
        highscores = new int[podium];
        players = new string[podium];
        
        for (int i = 0; i < podium; i++) {
            highscores[i] = PlayerPrefs.GetInt(highscorekey + i, 0);
            players[i] = PlayerPrefs.GetString(playernamekey + i, "DAV");
        }

        return highscores;
    }

    public static int[] GetScores() {
        if (highscores == null) {
            LoadScores();
        }

        return highscores;
    }

    public static string[] getPlayers() {
        if (players == null) {
            LoadScores();
        }

        return players;
    }

    public static void SaveScore(int score, string playerName) {
        if (highscores == null) {
            LoadScores();
        }

        for (int i = 0; i < highscores.Length; i++) {
            var savedScore = highscores[i];
            if (score > savedScore) {
                var name = playerName == null ? "DAV" : playerName.ToUpper();
                highscores[i] = score;
                players[i] = name;
                PlayerPrefs.SetInt(highscorekey + i, score);
                PlayerPrefs.SetString(playernamekey + i, name);
                return;
            }
        }
    }
}
