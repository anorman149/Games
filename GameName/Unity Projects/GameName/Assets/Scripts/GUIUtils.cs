using UnityEngine;

public class GUIUtils : MonoBehaviour {

    public static Font font;

    static GUIUtils() {
        font = Resources.Load("Fonts/Younger than me", typeof(Font)) as Font;
    }

    public static GUIStyle getDamageText() {
        GUIStyle style = new GUIStyle();

        style.normal.textColor = Color.red;
        style.fontSize = 18;
        style.font = font;

        return style;
    }

    public static GUIStyle getHeartText() {
        GUIStyle style = new GUIStyle();

        style.normal.textColor = new Color(.32f, .77f, .32f); //Green Color
        style.font = font;

        return style;
    }

    public static GUIStyle getCoinText() {
        GUIStyle style = new GUIStyle();

        style.normal.textColor = Color.yellow;
        style.font = font;

        return style;
    }

    public static GUIStyle getEndLevelText() {
        GUIStyle style = new GUIStyle();

        style.normal.textColor = Color.white;
        style.fontSize = 26;
        style.font = font;

        return style;
    }
}
