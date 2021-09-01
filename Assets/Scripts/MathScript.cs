using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathScript : MonoBehaviour
{
    PlayerScript player;
    public string currentStr = "";
    public Text text;
    public int maxChars;
    static KeyCodeString[] numberKeyCodes = new KeyCodeString[]{
        new KeyCodeString("0", KeyCode.Alpha0),
        new KeyCodeString("1", KeyCode.Alpha1),
        new KeyCodeString("2", KeyCode.Alpha2),
        new KeyCodeString("3", KeyCode.Alpha3),
        new KeyCodeString("4", KeyCode.Alpha4),
        new KeyCodeString("5", KeyCode.Alpha5),
        new KeyCodeString("6", KeyCode.Alpha6),
        new KeyCodeString("7", KeyCode.Alpha7),
        new KeyCodeString("8", KeyCode.Alpha8),
        new KeyCodeString("9", KeyCode.Alpha9),
        new KeyCodeString("0", KeyCode.Keypad0),
        new KeyCodeString("1", KeyCode.Keypad1),
        new KeyCodeString("2", KeyCode.Keypad2),
        new KeyCodeString("3", KeyCode.Keypad3),
        new KeyCodeString("4", KeyCode.Keypad4),
        new KeyCodeString("5", KeyCode.Keypad5),
        new KeyCodeString("6", KeyCode.Keypad6),
        new KeyCodeString("7", KeyCode.Keypad7),
        new KeyCodeString("8", KeyCode.Keypad8),
        new KeyCodeString("9", KeyCode.Keypad9),
        // new KeyCodeString("+", KeyCode.KeypadPlus),
        // new KeyCodeString("-", KeyCode.KeypadMinus),
        // new KeyCodeString("*", KeyCode.KeypadMultiply),
        // new KeyCodeString("/", KeyCode.KeypadDivide),
        // new KeyCodeString("+", KeyCode.Plus),
        // new KeyCodeString("-", KeyCode.Minus),
        // new KeyCodeString("/", KeyCode.Slash),
        // new KeyCodeString("*", KeyCode.Asterisk),
    };
    void Start()
    {
        currentStr = "";
        player = gameObject.GetComponent<PlayerScript>();
    }

    void Update()
    {
       UpdateText();
    }

    void UpdateText() 
    {
        if (currentStr.Length < maxChars) {
            for (var i = 0; i < numberKeyCodes.Length; i++) {
                var code = numberKeyCodes[i];
                if (Input.GetKeyDown(code.code)) {
                    currentStr += code.str;
                    text.text = currentStr;
                }
            }
        }

        if (currentStr.Length > 0 && Input.GetKeyDown(KeyCode.Backspace)) {
            currentStr = "";
            text.text = "";
        }

        if (currentStr.Length > 0 && Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) {
            Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies) {
                if (enemy.operation.result == int.Parse(currentStr)) {
                    enemy.Damage();
                }
            }

            currentStr = "";
            text.text = "";
        }
    }
}
