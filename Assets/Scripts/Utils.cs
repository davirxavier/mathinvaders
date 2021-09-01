using System.Collections;
using UnityEngine;

public static class Utils
{
    public static Vector3 LerpEase(float time, float duration, Vector3 startPosition, Vector3 endPosition) {
        float t = time / duration;
        t = t * t * (3f - 2f * t);

        return Vector3.Lerp(startPosition, endPosition, t);
    }
    /**
     * Coroutine to create a flash effect on all sprite renderers passed in to the function.
     *
     * @param sprites   a sprite renderer array
     * @param numTimes  how many times to flash
     * @param delay     how long in between each flash
     * @param disable   if you want to disable the renderer instead of change alpha
     */
    public static IEnumerator FlashSprites(SpriteRenderer[] sprites, int numTimes, float delay, bool disable = false) {
        // number of times to loop
        for (int loop = 0; loop < numTimes; loop++) {            
            // cycle through all sprites
            for (int i = 0; i < sprites.Length; i++) {                
                if (disable) {
                    // for disabling
                    sprites[i].enabled = false;
                } else {
                    // for changing the alpha
                    sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 0.5f);
                }
            }
 
            // delay specified amount
            yield return new WaitForSeconds(delay);
 
            // cycle through all sprites
            for (int i = 0; i < sprites.Length; i++) {
                if (disable) {
                    // for disabling
                    sprites[i].enabled = true;
                } else {
                    // for changing the alpha
                    sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 1);
                }
            }
 
            // delay specified amount
            yield return new WaitForSeconds(delay);
        }
    }
}
