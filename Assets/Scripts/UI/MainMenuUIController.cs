using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    public void OnStartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("BairuScene11");
    }
}
