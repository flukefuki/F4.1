using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCon : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SCENE Theme Park");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("ãÊèª×èÍ«Õ¹setting ");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
