using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera cam;
    private Vector3 _touchOrigin;
    private float _screenWidthMin;
    private float _screenWidthMax;

    private void Awake()
    {
        // Get the orthographic camera's width & height in the viewport space
        cam = Camera.main;
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.aspect * halfHeight;

        // Offset the screen so players don't touch the screen (leaves a margin)
        halfWidth -= 0.5f;
        _screenWidthMin = -halfWidth;
        _screenWidthMax = halfWidth;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _touchOrigin = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
            }
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector2 touchPosition = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
                // x offset from finger touch when further from right side of screen
                // if touchposition.x further from the right side of the screen, increase the offset
                float offsetMultiplyer = 1.3f;
                float xOffset = _screenWidthMax - (touchPosition.x * offsetMultiplyer);
                touchPosition.x -= xOffset;
                // lock the player to a point on screen
                touchPosition.y = -3f;
                transform.position = Vector3.Lerp(transform.position, touchPosition, 0.15f);

                
                if (transform.position.x > _screenWidthMax)
                {
                    transform.position = new Vector2(_screenWidthMax, transform.position.y);
                }
                else if (transform.position.x < _screenWidthMin)
                {
                    transform.position = new Vector2(_screenWidthMin, transform.position.y);
                }
                
            }
        }
    }
}
