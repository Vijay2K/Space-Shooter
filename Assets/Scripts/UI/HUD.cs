using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;

    public void UpdateScoreUI(int _score)
    {
        score += _score;
        scoreText.text = score.ToString(); 
    }
}
