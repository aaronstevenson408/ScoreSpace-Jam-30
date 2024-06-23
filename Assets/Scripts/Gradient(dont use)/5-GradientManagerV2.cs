// I apologize for the confusion. It seems the shader is rendering in front of your sprites, which isn't what we want. Let's modify the approach to ensure the gradient renders behind everything else. We'll use a separate camera to render the background.
// Here's an updated version of the GradientManager script:
// Unity Gradient Manager with Background CameraClick to open code
// To use this updated script:

// Make sure you still have the shader created as described in the previous response.
// Replace the contents of your GradientManager script with this new code.
// In your scene:

// Create a new empty GameObject and name it "Background Manager"
// Add the GradientManager script to this new GameObject
// Adjust the colors and heights in the inspector as needed


// Ensure your main camera is set up correctly:

// It should have a higher depth than -1
// Its clear flags should be set to "Depth Only"



// This approach creates a separate camera that renders only the gradient, and it does so before your main camera renders the scene. This ensures the gradient appears behind all your sprites.
// If you're still having issues:

// Check the Console for any error messages.
// In the Scene view, look for the newly created "Background Camera" object. It should be a child of your "Background Manager" object.
// Make sure your main camera's depth is greater than -1 (0 or higher).
// Verify that your sprites are being rendered by the main camera and not accidentally assigned to a layer that's being culled.

// Let me know if this solves the issue or if you need any further adjustments!
// using UnityEngine;

[ExecuteInEditMode]
public class GradientManager : MonoBehaviour
{
    public Color groundColor = new Color(0.5f, 0.35f, 0.2f);
    public Color skyColor = Color.blue;
    public Color spaceColor = Color.black;
    public float skyHeight = 10f;
    public float spaceHeight = 20f;

    private Material gradientMaterial;
    private Camera backgroundCamera;

    void Start()
    {
        SetupBackgroundCamera();
        SetupGradientMaterial();
    }

    void SetupBackgroundCamera()
    {
        // Create a new camera for the background if it doesn't exist
        if (backgroundCamera == null)
        {
            GameObject bgCameraObj = new GameObject("Background Camera");
            backgroundCamera = bgCameraObj.AddComponent<Camera>();
            bgCameraObj.transform.SetParent(transform);
        }

        // Setup the background camera
        backgroundCamera.clearFlags = CameraClearFlags.Nothing;
        backgroundCamera.cullingMask = 0; // Render nothing
        backgroundCamera.depth = -1; // Render before everything
        backgroundCamera.useOcclusionCulling = false;
        backgroundCamera.allowHDR = false;
        backgroundCamera.allowMSAA = false;
    }

    void SetupGradientMaterial()
    {
        if (gradientMaterial == null)
        {
            Shader gradientShader = Shader.Find("Custom/GradientBackground");
            if (gradientShader == null)
            {
                Debug.LogError("Gradient shader not found!");
                return;
            }
            gradientMaterial = new Material(gradientShader);
        }

        UpdateGradient();
    }

    void Update()
    {
        UpdateGradient();
    }

    void UpdateGradient()
    {
        if (gradientMaterial == null) return;

        gradientMaterial.SetColor("_GroundColor", groundColor);
        gradientMaterial.SetColor("_SkyColor", skyColor);
        gradientMaterial.SetColor("_SpaceColor", spaceColor);
        gradientMaterial.SetFloat("_SkyHeight", skyHeight);
        gradientMaterial.SetFloat("_SpaceHeight", spaceHeight);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (gradientMaterial == null)
        {
            Graphics.Blit(source, destination);
            return;
        }

        // Only render the gradient if this is the background camera
        if (Camera.current == backgroundCamera)
        {
            Graphics.Blit(null, destination, gradientMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    void OnValidate()
    {
        UpdateGradient();
    }
}