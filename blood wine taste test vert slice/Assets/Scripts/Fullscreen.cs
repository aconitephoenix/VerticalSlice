using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    // Set the sprite to fill the screen
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteRenderer == null) return;

        float cameraHeight = Camera.main.orthographicSize * 2;

        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = _spriteRenderer.sprite.bounds.size;

        Vector2 scale = transform.localScale;

        if (cameraSize.x >= cameraSize.y)
        {
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        {
            scale *= cameraSize.y / spriteSize.y;
        }

        transform.position = Vector2.zero;
        transform.localScale = scale;
    }
}