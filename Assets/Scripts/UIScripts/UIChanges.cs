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
    private TextMeshProUGUI _infoText;
    [SerializeField]
    private TextMeshProUGUI _timerText;

    [Header("Buttons")]
    [SerializeField]
    private Button _restartButton;
    [Header("Images")]
    [SerializeField]
    private Image _background;

    private Fade _fadeComp;

    private void Start()
    {

        PickupSystem.onAddScore += ChangeScore;
        FinishZone.onEnterFinish += ChangeEndText;
        FinishZone.onRestart += ShowEndScreen;
        FinishZone.onExitFinish += Disable;
        EnemyMovement.onSpottedPlayer += ShowEndScreen;
        Timer.onTimeOver += ShowEndScreen;
        Timer.updateTime += UpdateTime;
        Disable();
        StartMessage();
    }

    void OnDestroy()
    {
        PickupSystem.onAddScore -= ChangeScore;
        FinishZone.onEnterFinish -= ChangeEndText;
        FinishZone.onRestart -= ShowEndScreen;
        FinishZone.onExitFinish -= Disable;
        EnemyMovement.onSpottedPlayer -= ShowEndScreen;
        Timer.onTimeOver -= ShowEndScreen;
        Timer.updateTime -= UpdateTime;

    }

    private void ChangeScore(int totalScore)
    {
        _scoreText.text = "Score: " + totalScore.ToString();
    }

    private void ChangeEndText(string text)
    {

        _infoText.gameObject.SetActive(true);
        _infoText.text = text;
        _fadeComp.HasToFade = false;

    }

    private void ShowEndScreen(bool hasDied, string infoText)
    {
        _infoText.gameObject.SetActive(true);
        _infoText.text = infoText;
        _background.gameObject.SetActive(true);
        _fadeComp.HasToFade = false;
        _timerText.gameObject.SetActive(false);
        if (hasDied)
            _infoText.color = Color.red;
        else
            _infoText.color = Color.white;
        _restartButton.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    private void Disable()
    {
        if(_infoText)
            _infoText.gameObject.SetActive(false);
        if (_restartButton)
            _restartButton.gameObject.SetActive(false);
        if (_background)
            _background.gameObject.SetActive(false);
    }

    private void StartMessage()
    {
        if (_infoText)
        {
            _fadeComp = _infoText.gameObject.GetComponent<Fade>();
            _fadeComp.HasToFade = true;
            _infoText.gameObject.SetActive(true);
            _infoText.text = "FIND ALL THE STARS AND FIND YOUR WAY OUT!";
        }
    }

    private void UpdateTime(string time)
    {
        _timerText.text = time;
    }

}
