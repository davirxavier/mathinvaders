 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 using TMPro;

 public class ColorChange : MonoBehaviour {
     public Color[] colors;
     public int currentIndex = 0;
     private int nextIndex;
     public float changeColourTime = 2.0f;
     private float lastChange = 0.0f;
     private float timer = 0.0f;
     Image image;
     public TextMeshProUGUI text;
     
     void Start() {
         image = GetComponent<Image>();
         if (colors == null || colors.Length < 2)
             Debug.Log ("Need to setup colors array in inspector");
         
         nextIndex = (currentIndex + 1) % colors.Length;    
     }
     
     void Update() {
         timer += Time.unscaledDeltaTime;
         
         if (timer > changeColourTime) {
             currentIndex = (currentIndex + 1) % colors.Length;
             nextIndex = (currentIndex + 1) % colors.Length;
             timer = 0.0f;
         }
         var color = Color.Lerp(colors[currentIndex], colors[nextIndex], timer / changeColourTime);
         if (image != null) {
             image.color = color;
         }
         if (text != null) {
             text.color = color;
         }
     }
 }