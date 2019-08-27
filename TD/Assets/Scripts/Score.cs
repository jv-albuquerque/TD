using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore = null;
    [SerializeField] private TextMeshProUGUI textHighScore = null;

    private int score = 0;

    //Start with the highscore updated or zero if it hasn't a highscore yet
    private void Start()
    {
        textHighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    /// <summary>
    /// Function that increase the score
    /// point = the number incresed in the score
    /// </summary>
    public void AddScore(int point)
    {
        point = (int) Random.Range(0, 1000);

        score += point;

        textScore.text = score.ToString();
    }

    /// <summary>
    /// Function used to save the highscore in the playerprefs
    /// </summary>
    public void SaveHighScore()
    {
        if(PlayerPrefs.GetInt("HighScore", 0) < score)
            PlayerPrefs.SetInt("HighScore", score);
    }
}
