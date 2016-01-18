using UnityEngine;

public class GUIUtils : MonoBehaviour {

    public static Font font;
    public static GUIStyle damageStyle = new GUIStyle();
    public static GUIStyle heartStyle = new GUIStyle();
    public static GUIStyle coinStyle = new GUIStyle();
    public static GUIStyle endLevelStyle = new GUIStyle();

    static GUIUtils() {
        font = Resources.Load("Fonts/Younger than me", typeof(Font)) as Font;

        damageStyle = initDamageText();
        heartStyle = initHeartText();
        coinStyle = initCoinText();
        endLevelStyle = initEndLevelText();
    }

    private static GUIStyle initDamageText() {
        damageStyle.normal.textColor = Color.red;
        damageStyle.fontSize = 18;
        damageStyle.font = font;

        return damageStyle;
    }

    private static GUIStyle initHeartText() {
        heartStyle.normal.textColor = new Color(.32f, .77f, .32f); //Green Color
        heartStyle.font = font;

        return heartStyle;
    }

    private static GUIStyle initCoinText() {
        coinStyle.normal.textColor = Color.yellow;
        coinStyle.font = font;

        return coinStyle;
    }

    private static GUIStyle initEndLevelText() {
        endLevelStyle.normal.textColor = Color.white;
        endLevelStyle.fontSize = 26;
        endLevelStyle.font = font;

        return endLevelStyle;
    }
}
