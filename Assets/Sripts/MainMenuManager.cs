using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); // Loads Level 1 (game) bcz our main game it have index 1. Level 1 is the game in project. (used for start button in mainmenu)
    }

    public void QuitGame()
    {
        for (int i = 1; i <= 8; i++) //here it checks all scores from 1 to 8
        {
            // It says that in case one of saved scores exists in PlayerPrefs it gets deleted when quit button is clicked so its again a new fresh scoreboard
            
            if (PlayerPrefs.HasKey("Score" + i)) 
            {
                PlayerPrefs.DeleteKey("Score" + i);
            }
        }
        PlayerPrefs.Save(); 



        //Here the UNITY_EDITOR is being used in if statment  bcz this when we are testing in editor and we click on quit button, so game exits from editor so we know quit button is working. Application Quit: Here this is for excutable build(it means not in editor anymore)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  
#else
    Application.Quit();
#endif
    }
}