using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuButton : MonoBehaviour
{
    private static Color hoverColor = new Color(255, 255, 255, 1f);
    private static Color idleColor = new Color(0, 0, 0, 0.31f);
    public TextMeshProUGUI text;
    Image image;
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    void OnMouseEnter() {
        image.color = hoverColor;
        text.color = Color.black;
    }

    void OnMouseExit() {
        image.color = idleColor;
        text.color = Color.white;
    }
}
