using UnityEngine;
using TMPro;




public class ScoreboardDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreboardText; // It's where the text will be shown on scoreboard(screen labels) 

    void Start()
    {
        bool checkScoreFound = false;  // We say like we dont know yet if we have any saved scores. so it starts as false 

        scoreboardText.text = "Previous Times:\n";  // Scoreboard Header for onlu saaved scores 

        for (int i = 1; i <= 8; i++)                // We support max 8 scores in scoreboard. 
        {
            if (PlayerPrefs.HasKey("Score" + i))    // Here we we check if score exost
            {

                float time = PlayerPrefs.GetFloat("Score" + i); // yes? then we read it in order to get the saved time value in PlayerPrefs

                //Break total of seconds into mins and secs
                
                int Min = Mathf.FloorToInt(time / 60);         
                float Sec = time % 60f;


                scoreboardText.text += i + "." + Min + ":" + Sec.ToString("00.00") + "\n";  // Here scores gets added to scoreboard text in good format for minutes and seconds


                checkScoreFound = true;  // Indicates that we found atleast one score, so its true(we know then there are scores )
            }

         }

        if (!checkScoreFound) // In case no scores is there/found so we write No scores yet
        {
            scoreboardText.text = "No scores yet.";

        }
    }
}