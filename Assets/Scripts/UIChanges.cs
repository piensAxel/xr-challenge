using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIChanges : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    private void Start()
    {
        PickupPoints.onAddScore += ChangeScore;
    }

    public void ChangeScore(int totalScore)
    {
        _scoreText.text = "Score: " + totalScore.ToString();
    }
}
