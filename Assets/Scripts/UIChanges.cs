using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIChanges : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _endText;
    [SerializeField]
    private string _deathText;
    [Header("Buttons")]
    [SerializeField]
    private Button _restartButton;


    private void Start()
    {
        PickupPoints.onAddScore += ChangeScore;
        FinishZone.onEnterFinish += ChangeEndText;
        FinishZone.onRestart += ShowEndScreen;
        FinishZone.onExitFinish += Disable;
        EnemyMovement.onSpottedPlayer += ShowEndScreen;
        Disable();
    }

    private void ChangeScore(int totalScore)
    {
        _scoreText.text = "Score: " + totalScore.ToString();
    }

    private void ChangeEndText(string text)
    {

        _endText.gameObject.SetActive(true);
        _endText.text = text;
    }

    private void ShowEndScreen(bool hasDied)
    {
        if (hasDied)
        {
            _endText.gameObject.SetActive(true);
            _endText.text = _deathText;
        }
        _restartButton.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }


    private void Disable()
    {
        _endText.gameObject.SetActive(false);
        _restartButton.gameObject.SetActive(false);

    }


}
