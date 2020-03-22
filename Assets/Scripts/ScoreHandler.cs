using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    #region Cached references

    private static Text _scoreText;

    #endregion

    #region Private variables

    private static int _currentScore;

    #endregion


    private void Awake()
    {
        _currentScore = 0;
        _scoreText = GetComponent<Text>();
        _scoreText.text = 0.ToString();
    }

    public static void ScorePoints(int points)
    {
        _currentScore += points;
        _scoreText.text = _currentScore.ToString();

    }

}
