using UnityEngine;

[ExecuteInEditMode]
public class GradientBackground : MonoBehaviour
{
    public Color groundColor = new Color(0.5f, 0.35f, 0.2f);
    public Color skyColor = Color.blue;
    public Color spaceColor = Color.black;
    public float skyHeight = 10f;
    public float spaceHeight = 20f;

    private Material gradientMaterial;
    private MeshRenderer meshRenderer;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
            return;
        }

        SetupQuad();
        SetupMaterial();
    }

    void SetupQuad()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        if (meshRenderer == null)
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
        if (meshFilter == null)
            meshFilter = gameObject.AddComponent<MeshFilter>();

        meshFilter.mesh = CreateQuadMesh();
    }

    Mesh CreateQuadMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] {
            new Vector3(-1, -1, 0),
            new Vector3(1, -1, 0),
            new Vector3(1, 1, 0),
            new Vector3(-1, 1, 0)
        };
        mesh.uv = new Vector2[] {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1)
        };
        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
        return mesh;
    }

    void SetupMaterial()
    {
        Shader gradientShader = Shader.Find("Custom/GradientBackground");
        if (gradientShader == null)
        {
            Debug.LogError("Gradient shader not found!");
            return;
        }
        gradientMaterial = new Material(gradientShader);
        meshRenderer.material = gradientMaterial;

        UpdateGradient();
    }

    void Update()
    {
        UpdateGradient();
        UpdateQuadTransform();
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

    void UpdateQuadTransform()
    {
        if (mainCamera == null) return;

        float orthoHeight = mainCamera.orthographicSize;
        float orthoWidth = orthoHeight * mainCamera.aspect;

        transform.position = mainCamera.transform.position + Vector3.forward;
        transform.localScale = new Vector3(orthoWidth * 2, orthoHeight * 2, 1);
    }

    void OnValidate()
    {
        UpdateGradient();
    }
}