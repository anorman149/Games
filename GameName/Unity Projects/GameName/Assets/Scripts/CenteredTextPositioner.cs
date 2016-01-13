using UnityEngine;

public class CenteredTextPositioner : IFloatingTextPositioner {

    private float _speed;
    private float _textPosition;

    public CenteredTextPositioner(float speed) {
        _speed = speed;
    }

    public bool GetPosition(ref Vector2 position, GUIContent content, Vector2 size) {
        _textPosition += Time.deltaTime * _speed;

        //Make sure our time isn't up
        if(_textPosition > 1) {
            return false;
        }

        //Center the Text and let it scroll off sreen
        position = new Vector2(Screen.width / 2f - size.x / 2f, Mathf.Lerp(Screen.height / 2f + size.y, 0, _textPosition));

        return true;
    }
}
