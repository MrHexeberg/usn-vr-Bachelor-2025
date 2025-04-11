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
            scoreboardText.text += index + ". " + time.ToString("F2") + "s\n";
            index++;
        }
    }
}
