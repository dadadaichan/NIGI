using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void ReloadCurrentScene()// 現在のシーンをリロード
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
