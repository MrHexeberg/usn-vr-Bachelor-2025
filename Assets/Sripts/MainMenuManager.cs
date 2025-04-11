using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); // Loads Level 1 (game)
    }

    public void QuitGame()
    {
        Debug.Log("Quit button clicked");

        // Clear the saved scores
        PlayerPrefs.DeleteKey("Scores"); //cleans scores previous afte clcking on quitr
        PlayerPrefs.Save();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}