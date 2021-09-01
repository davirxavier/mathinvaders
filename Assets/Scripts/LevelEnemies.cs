using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnemies : MonoBehaviour
{
  public static int[][] getLevelEnemies(int level) {
    var cl = level;
    if (cl > 20 && cl % 20 == 0) {
      return enemiesByLevel[20];
    } else if (cl > enemiesByLevel.Length) {
      var lvl = Random.Range(1, enemiesByLevel.Length);
      while (lvl % 20 == 0) {
        lvl = Random.Range(1, enemiesByLevel.Length);
      }
      return enemiesByLevel[lvl];
    } else {
      return cl < 0 || cl >= enemiesByLevel.Length ? enemiesByLevel[0] : enemiesByLevel[cl];
    }
  }

  // 0 - Simple enemy
  // 1 - Heavy enemy
  // 2 - Homing enemy
  // 3 - Laser enemy
  // 4 - Boss

    private static int[][][] enemiesByLevel = new int[][][] {
        new int[][] {
            new int[] {-1, -1, -1, -1, -1, -1, -1},
              new int[] {-1, -1, -1, -1, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        // Tier 1
        new int[][] {
            new int[] {-1, -1, -1, 00, -1, -1, -1},
              new int[] {-1, -1, -1, -1, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, 00, -1, 00, -1, -1},
              new int[] {-1, -1, -1, -1, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, 01, -1, 01, -1, -1},
              new int[] {-1, -1, -1, -1, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {00, -1, 01, -1, 01, -1, 00},
              new int[] {-1, -1, -1, -1, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, 00, -1, -1, -1, 00, -1},
              new int[] {-1, -1, 01, 01, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, 01, -1, -1, -1, 01, -1},
              new int[] {-1, -1, 01, 01, -1 , -1},
            new int[] {-1, 00, -1, -1, -1, 00, -1},
        },
        new int[][] {
            new int[] {-1, -1, 00, 01, 00, -1, -1},
              new int[] {-1, 00, -1, -1, 00 , -1},
            new int[] {-1, -1, -1, 01, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, 01, 01, 01, -1, -1},
              new int[] {-1, 00, -1, -1, 00 , -1},
            new int[] {-1, -1, 00, 00, 00, -1, -1},
        },
        new int[][] {
            new int[] {-1, 01, 00, 00, 00, 01, -1},
              new int[] {-1, 01, 01, 01, 01 , -1},
            new int[] {-1, 01, -1, -1, -1, 01, -1},
        },
        new int[][] {
            new int[] {-1, 01, -1, 01, -1, 01, -1},
              new int[] {00, 01, -1, -1, 01, 00},
            new int[] {-1, -1, 00, 01, 00, -1, -1},
        },
        // End of tier 1
        // Tier 2
        new int[][] {
            new int[] {-1, -1, -1, 02, -1, -1, -1},
              new int[] {-1, -1, -1, -1, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, 00, 02, 00, -1, -1},
              new int[] {-1, -1, -1, -1, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, 02, 00, 02, -1, -1},
              new int[] {-1, -1, -1, -1, -1, -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, -1, 02, -1, -1, -1},
              new int[] {-1, 01, -1, -1, 01 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, -1, 00, -1, -1, -1},
              new int[] {-1, 02, -1, -1, 02, -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, 01, -1, 01, -1, -1},
              new int[] {-1, 02, -1, -1, 02 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, 02, -1, 02, -1, -1},
              new int[] {-1, -1, 02, 02, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, 00, 02, 00, -1, -1},
              new int[] {-1, 01, -1, -1, 01 , -1},
            new int[] {-1, -1, 02, -1, 02, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, 01, 02, 01, -1, -1},
              new int[] {-1, -1, 02, 02, -1 , -1},
            new int[] {-1, -1, -1, 01, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, -1, 04, -1, -1, -1},
              new int[] {-1, -1, -1, -1, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        // End of tier 2
        // Tier 3
        new int[][] {
            new int[] {-1, -1, -1, 03, -1, -1, -1},
              new int[] {-1, -1, -1, -1, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, 02, -1, 03, -1, 02, -1},
              new int[] {-1, -1, -1, -1, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, -1, 02, -1, -1, -1},
              new int[] {03, -1, -1, -1, -1 , 03},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, 00, -1, 03, -1, 00, -1},
              new int[] {-1, -1, 03, 03, -1 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, 02, 02, 02, -1, -1},
              new int[] {-1, 03, -1, -1, 03 , -1},
            new int[] {-1, -1, -1, -1, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, -1, 01, 01, 01, -1, -1},
              new int[] {-1, 02, -1, -1, 02 , -1},
            new int[] {-1, -1, -1, 03, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, 00, 01, -1, 01, 00, -1},
              new int[] {02, -1, 01, 01, -1 , 02},
            new int[] {-1, -1, -1, 03, -1, -1, -1},
        },
        new int[][] {
            new int[] {-1, 00, -1, 00, -1, 00, -1},
              new int[] {-1, 00, 00, 00, 00 , -1},
            new int[] {-1, -1, -1, 02, -1, -1, -1},
        },
        // End of tier 3
        // Random
    };
}
