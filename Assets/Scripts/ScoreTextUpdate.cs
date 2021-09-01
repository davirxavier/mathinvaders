using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextUpdate : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerScore.GetCurrentPoints() + "P";
    }

    void Update()
    {
        
    }
}
