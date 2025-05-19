using UnityEngine;
using System.Collections;


public class GameTimer : MonoBehaviour
{
    public static float playTime = 0f;  // This is like it starts at 0secs, it will count up while player is playing  the game.
    public bool isRunning = true;       // This indicates that our timer is working(counting). Not stopped



    void Update()
    {
        if (isRunning) {

            playTime += Time.deltaTime;    // Time.deltaTime:  is the time that is being passed since last frame to playTIme

        }
           




        if (Input.GetKeyDown(KeyCode.Escape))  // Esc button is pressed on keyboard, so timer being rest/no save and we go to main menu again
        {


            RestartWithoutSave();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Level 2");
        }


    }

    public void StopTimer()
    {
        if (isRunning == true) // Ok we says here that in case our timer is running:
        {

            isRunning = false;  // It gets turned off here

            StartCoroutine(LoadMainMenuAfterDelay()); //Delay, wait 5secs before going to mainemnu

            SaveTime(playTime);              // time being saved here "playtime" that was in beginning 0secs when we started so player can see score later.

           
        }
    }

    IEnumerator LoadMainMenuAfterDelay() // Function Responsible on delay 5sec
    {
        yield return new WaitForSeconds(5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0); // Loads scene by build index (Main Menu) that is Level 2. Index  is 0 in buildsettings in our project. so it gets reloaded. 
    }

    void ResetTimer() // Reset timer to 0sec
    {
        playTime = 0f;

    }

    void RestartWithoutSave()
    {

        isRunning = false; // Timer stops

        ResetTimer(); // We decide to reset timer when we do restart
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Level 2");

    }

    void SaveTime(float newTime)
    {
        
        for (int i = 1; i <= 8; i++) //We saving 8 scores 
        {
            if (!PlayerPrefs.HasKey("Score" + i)) // cehck if there is no slot, 
            {
                PlayerPrefs.SetFloat("Score" + i, newTime); //First we save time to Playerprefs and then permentaly
                PlayerPrefs.Save();
                return;
            }
        }
    }
}

