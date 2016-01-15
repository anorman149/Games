using UnityEngine;

public class FromWorldPointTextPositioner : IFloatingTextPositioner {

    private Vector3 _worldPosition;
    private float _timeToLive;
    private float _speed;
    private float _offSet;

    public FromWorldPointTextPositioner(Vector3 worldPosition, float timeToLive, float speed) {
        _worldPosition = worldPosition;
        _timeToLive = timeToLive;
        _speed = speed;
    }

    public bool GetPosition(ref Vector2 position, GUIContent content, Vector2 size) {

        //Check to see if the Time is up
        if((_timeToLive -= Time.deltaTime) <= 0) {
            return false;
        }

        //Grab the world position for the Object
        Vector3 worldPosition = Camera.main.WorldToScreenPoint(_worldPosition);

        //Alter the x and y for the Object
        position.x = worldPosition.x - (size.x / 2);
        position.y = Screen.height - worldPosition.y - _offSet;

        _offSet += Time.deltaTime * _speed;

        return true;
    }
}
