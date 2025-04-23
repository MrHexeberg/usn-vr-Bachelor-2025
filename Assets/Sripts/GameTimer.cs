using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public static float playTime = 0f;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
            playTime += Time.deltaTime;


        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     Debug.Log("T key was pressed!"); //testing button T to know if timer works before we add puzzle 3 so timer stops..
        //     StopTimer();
        //     UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Level 2");
        // }

        if (Input.GetKeyDown(KeyCode.Escape))
         {
           
           StopTimer();
           ResetTimer(); 
           UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Level 2");
         }  


    }

    public void StopTimer()
    {
        isRunning = false;
        SaveTime(playTime);

        // here we get littlee delayS
        StartCoroutine(LoadMainMenuAfterDelay(5f)); 
    }

    IEnumerator LoadMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0); // Loads scene by build index (Main Menu)
    }

    void ResetTimer()
    {
        playTime=0f;

    }

    void RestartWithoutSave()
    {

        StopTimer();
        ResetTimer();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Level 2");

    }

    void SaveTime(float newTime)
    {
        string json = PlayerPrefs.GetString("Scores", "");
        ScoreData data = string.IsNullOrEmpty(json) ? new ScoreData() : JsonUtility.FromJson<ScoreData>(json);

        data.times.Add(newTime); // Save current time

        string updatedJson = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("Scores", updatedJson);
        PlayerPrefs.Save();
    }
}
