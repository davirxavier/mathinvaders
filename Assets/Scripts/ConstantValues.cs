using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstantValues
{
    public static string currentPlayerName = "DAV";
    public static int podiumCount = 10;
    public static float minEnemyHzSpeed = 0.01f;
    public static float maxEnemyHzSpeed = 0.022f;
    public static float minEnemyVrSpeed = 0.3f;
    public static float maxEnemyVrSpeed = 1.6f;
    public static int currentLevel = 1;
    public static Vector2[][] positions;
    public static int[][] currentEnemies = new int[3][];
    static ConstantValues() {
        positions = new Vector2[3][];

        var yStart = 4.6f;
        for (var i = 0; i < 3; i++) {
            var xStart = (i+1) % 2 != 0 ? -7.8f : -6.4f;

            var max = (i+1) % 2 == 0 ? 6 : 7;
            if (positions[i] == null) {
                    positions[i] = new Vector2[max];
                }
            for (var j = 0; j < max; j++) {
                positions[i][j] = new Vector2(xStart + (2.6f * j), yStart - (2f * i));
            }
        }
    }
}
