using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    private Text _scoreText;

    private int _currentScore;


    private void Awake()
    {
        _currentScore = 0;
        _scoreText = GetComponent<Text>();
        PrintScore(_currentScore);
    }

    public void ScorePoints(int points)
    {
        _currentScore += points;
    }

    private void PrintScore(int points)
    {
        _scoreText.text = _currentScore.ToString();
    }



}
