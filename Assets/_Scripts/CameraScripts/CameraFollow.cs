using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float stepOutOfCenter;
    public float scrollSpeed;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        Vector2 playerPostion = playerTransform.position;
        Vector2 playerPositonOnScreen = _camera.WorldToScreenPoint(playerPostion);
        Vector2 playerPositionOnScreenNormalized = new Vector2(playerPositonOnScreen.x / _camera.pixelWidth, playerPositonOnScreen.y / _camera.pixelHeight);

        float deltaX = playerPositionOnScreenNormalized.x - 0.5f;
        float deltaY = playerPositionOnScreenNormalized.y - 0.5f;

        if (Mathf.Abs(deltaX) >= stepOutOfCenter)
            transform.Translate(new Vector2(scrollSpeed * Mathf.Sign(deltaX), 0) * Time.deltaTime);
        if (Mathf.Abs(deltaY) >= stepOutOfCenter)
            transform.Translate(new Vector2(0, scrollSpeed * Mathf.Sign(deltaY)) * Time.deltaTime);

    }
}
