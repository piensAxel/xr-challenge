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
    [Header("Images")]
    [SerializeField]
    private Image _background;

    private void Start()
    {
        PickupPoints.onAddScore += ChangeScore;
        FinishZone.onEnterFinish += ChangeEndText;
        FinishZone.onRestart += ShowEndScreen;
        FinishZone.onExitFinish += Disable;
        EnemyMovement.onSpottedPlayer += ShowEndScreen;
        Disable();
    }

    void OnDestroy()
    {
        PickupPoints.onAddScore -= ChangeScore;
        FinishZone.onEnterFinish -= ChangeEndText;
        FinishZone.onRestart -= ShowEndScreen;
        FinishZone.onExitFinish -= Disable;
        EnemyMovement.onSpottedPlayer -= ShowEndScreen;
    }
    private void Update()
    {
        print(_endText);
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
            _endText.color = Color.red;
            _background.gameObject.SetActive(true);
        }
        _restartButton.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void Disable()
    {
        _endText.gameObject.SetActive(false);
        _restartButton.gameObject.SetActive(false);
        _background.gameObject.SetActive(false);
    }


}
