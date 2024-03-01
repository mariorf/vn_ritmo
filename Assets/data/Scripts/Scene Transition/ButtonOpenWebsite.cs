using UnityEngine;
using UnityEngine.UI;

public class OpenWebsite : MonoBehaviour
{
    public string url;

    void Start()
    {
        Button button = GetComponent<Button>();
        
        button.onClick.AddListener(OpenWebPage);
    }
    
    void OpenWebPage()
    {
        Application.OpenURL(url);
    }
}