using TMPro;
using UnityEngine;

public class LoadNotification : MonoBehaviour
{
    [SerializeField] TMP_Text versionText;

    private void Awake()
    {
        versionText?.SetText($"v{Application.version}");
    }

    public void LinkTo(string url)
    {
        Application.OpenURL(url);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
