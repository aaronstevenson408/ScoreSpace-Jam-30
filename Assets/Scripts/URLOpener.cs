using UnityEngine;
using UnityEngine.UI;

public class URLOpener : MonoBehaviour
{
    [SerializeField] private string url = "https://example.com";
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OpenURL);
        }
        else
        {
            Debug.LogWarning("No Button component found on this GameObject.");
        }
    }

    private void OpenURL()
    {
        Application.OpenURL(url);
    }
}