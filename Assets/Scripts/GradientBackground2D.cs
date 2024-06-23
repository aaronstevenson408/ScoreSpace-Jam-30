using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class GradientBackground2D : MonoBehaviour
{
    public Color groundColor = new Color(0.5f, 0.35f, 0.2f);
    public Color skyColor = Color.blue;
    public Color spaceColor = Color.black;
    public float skyHeight = 10f;
    public float spaceHeight = 20f;

    private SpriteRenderer spriteRenderer;
    private Texture2D gradientTexture;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetupGradientTexture();
        UpdateGradient();
    }

    void SetupGradientTexture()
    {
        gradientTexture = new Texture2D(1, 256, TextureFormat.RGBA32, false);
        gradientTexture.wrapMode = TextureWrapMode.Clamp;
        gradientTexture.filterMode = FilterMode.Bilinear;
    }

    void Update()
    {
        UpdateGradient();
        UpdateSpriteTransform();
    }

    void UpdateGradient()
    {
        for (int y = 0; y < gradientTexture.height; y++)
        {
            float t = (float)y / (gradientTexture.height - 1);
            Color color;
            if (t < 0.5f)
            {
                color = Color.Lerp(groundColor, skyColor, t * 2);
            }
            else
            {
                color = Color.Lerp(skyColor, spaceColor, (t - 0.5f) * 2);
            }
            gradientTexture.SetPixel(0, y, color);
        }
        gradientTexture.Apply();

        Sprite gradientSprite = Sprite.Create(gradientTexture, new Rect(0, 0, 1, gradientTexture.height), new Vector2(0.5f, 0.5f), 100f);
        spriteRenderer.sprite = gradientSprite;

        spriteRenderer.sortingOrder = -32768; // Lowest possible sorting order
    }

    void UpdateSpriteTransform()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main camera not found!");
            return;
        }

        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // Set the sprite's width to match the camera's width
        spriteRenderer.size = new Vector2(cameraWidth, cameraHeight);

        // Position the sprite to cover the entire camera view
        transform.position = Camera.main.transform.position + new Vector3(0, 0, 1);

        Debug.Log($"Camera Ortho Size: {Camera.main.orthographicSize}, Aspect: {Camera.main.aspect}");
        Debug.Log($"Sprite Size: {spriteRenderer.size}, Position: {transform.position}");
    }

    void OnValidate()
    {
        if (spriteRenderer != null && gradientTexture != null)
        {
            UpdateGradient();
        }
    }
}