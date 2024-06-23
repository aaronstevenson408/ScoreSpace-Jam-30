using UnityEngine;

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