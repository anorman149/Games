using UnityEngine;

public class FloatingText : MonoBehaviour {

    public GUIContent content;
    public GUIStyle guiStyle;
    public IFloatingTextPositioner textPositioner;

    public static FloatingText Show(string text, GUIStyle guiStyle, IFloatingTextPositioner positioner) {
        GameObject go = new GameObject("Floating Text");

        FloatingText floatingText = go.AddComponent<FloatingText>();
        floatingText.guiStyle = guiStyle;
        floatingText.content = new GUIContent(text);
        floatingText.textPositioner = positioner;

        return floatingText;
    }

    public void OnGUI() {
        Vector2 position = new Vector2();
        Vector2 contentSize = guiStyle.CalcSize(content);

        //Check to see if the Time is up for the Text
        if(!textPositioner.GetPosition(ref position, content, contentSize)) {
            Destroy(gameObject);

            return;
        }

        //Go ahead and create the Label
        GUI.Label(new Rect(position.x, position.y, contentSize.x, contentSize.y), content, guiStyle);
    }
}
