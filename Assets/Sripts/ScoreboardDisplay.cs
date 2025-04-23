using UnityEngine;
using TMPro;



public class ScoreboardDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreboardText;

    void Start()
    {
        string json = PlayerPrefs.GetString("Scores", "");
        if (string.IsNullOrEmpty(json))
        {
            scoreboardText.text = "No scores yet.";
            return;
        }

        ScoreData data = JsonUtility.FromJson<ScoreData>(json);
        scoreboardText.text = "Previous Times:\n";

        int index = 1;
        foreach (float time in data.times)
        {
            int Min = Mathf.FloorToInt(time / 60);
            float Sec = time % 60f;


            scoreboardText.text += index + ". " + Min +":"+ Sec.ToString("00.00") + "\n";
            
            index++;
        }
    }
}
