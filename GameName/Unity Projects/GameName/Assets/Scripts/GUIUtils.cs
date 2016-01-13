using UnityEngine;

public class GUIUtils : MonoBehaviour {

    public static GUIStyle getDamageText() {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontSize = 18;

        return style;
    }

    public static GUIStyle getHeartText() {
        GUIStyle style = getDamageText();
        style.normal.textColor = Color.blue;

        return style;
    }

    public static GUIStyle getCoinText() {
        GUIStyle style = getDamageText();
        style.normal.textColor = Color.yellow;

        return style;
    }

    public static GUIStyle getEndLevelText() {
        GUIStyle style = getDamageText();
        style.normal.textColor = Color.white;
        style.fontSize = 20;

        return style;
    }
}
