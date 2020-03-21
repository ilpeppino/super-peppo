using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    private static Text _scoreText;

    private static int _currentScore;


    private void Awake()
    {
        _currentScore = 0;
        _scoreText = GetComponent<Text>();
        PrintScore();

    }

    public static void ScorePoints(int points)
    {
        _currentScore += points;
        
    }

    public  static void PrintScore()
    {
        _scoreText.text = _currentScore.ToString();
    }

}
