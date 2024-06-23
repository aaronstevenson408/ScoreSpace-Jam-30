using UnityEngine;

public class GradientBackground : MonoBehaviour
{
    public Color topColor = Color.blue;
    public Color bottomColor = Color.black;

    private void Start()
    {
        // Create a new texture and fill it with the gradient
        Texture2D tex = new Texture2D(1, 2);
        tex.SetPixel(0, 0, bottomColor);
        tex.SetPixel(0, 1, topColor);
        tex.Apply();

        // Create a sprite using the texture
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 1, 2), new Vector2(0.5f, 0.5f));

        // Add or get SpriteRenderer component and set its sprite
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer == null) renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;

        // Scale the sprite to fill the screen
        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(
            worldScreenWidth,
            worldScreenHeight,
            1
        );
    }
}