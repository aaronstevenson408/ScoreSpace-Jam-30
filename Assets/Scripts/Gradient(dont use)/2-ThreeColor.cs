// Certainly! We can modify the script to create a three-color gradient that transitions as the player moves upward. We'll use the player's y-position to determine how much of each color to show. Here's an updated version of the script:
// Unity 2D Three-Color Dynamic Gradient BackgroundClick to open code
// Here's how to use this updated script:

// Create an empty GameObject in your scene and name it "Background".
// Attach this DynamicGradientBackground script to the GameObject.
// Adjust the colors (groundColor, skyColor, spaceColor) in the Inspector to match your desired gradient.
// Set the skyHeight and spaceHeight values to determine where the transitions occur.

// This script does the following:

// Creates a three-color gradient texture.
// Updates the gradient based on the player's (or camera's) y-position.
// The bottom third of the gradient is always the ground color.
// The middle third transitions from sky color to space color as the player moves up.
// The top third is always the space color.

// As the player moves upward:

// Below skyHeight, the gradient will be mostly ground and sky colors.
// Between skyHeight and spaceHeight, the sky will gradually darken to the space color.
// Above spaceHeight, the gradient will be mostly space color, with a thin band of ground at the bottom.

// This approach allows for smooth transitions and maintains performance by updating a small texture rather than using a full-screen shader.
// Remember to adjust the skyHeight and spaceHeight values to match your game's scale. You might also want to add a small buffer to the world height in the Start method to ensure the gradient covers the entire screen even when the player is at the highest point.
// Let me know if you need any clarification or have any questions about implementing this in your project!



using UnityEngine;

public class DynamicGradientBackground : MonoBehaviour
{
    public Color groundColor = new Color(0.5f, 0.35f, 0.2f);  // Dirt brown
    public Color skyColor = Color.blue;
    public Color spaceColor = Color.black;

    public float skyHeight = 10f;  // Height where sky starts to transition to space
    public float spaceHeight = 20f;  // Height where it becomes fully space

    private SpriteRenderer spriteRenderer;
    private Texture2D gradientTexture;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        gradientTexture = new Texture2D(1, 3);
        UpdateGradient(0);

        // Scale the sprite to fill the screen
        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth, worldScreenHeight, 1);
    }

    private void Update()
    {
        if (Camera.main != null)
        {
            UpdateGradient(Camera.main.transform.position.y);
        }
    }

    private void UpdateGradient(float playerHeight)
    {
        float t = Mathf.Clamp01((playerHeight - skyHeight) / (spaceHeight - skyHeight));

        gradientTexture.SetPixel(0, 0, groundColor);
        gradientTexture.SetPixel(0, 1, Color.Lerp(skyColor, spaceColor, t));
        gradientTexture.SetPixel(0, 2, spaceColor);
        gradientTexture.Apply();

        Sprite sprite = Sprite.Create(gradientTexture, new Rect(0, 0, 1, 3), new Vector2(0.5f, 0.5f));
        spriteRenderer.sprite = sprite;
    }
}