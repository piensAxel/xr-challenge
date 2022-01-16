using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Fade : MonoBehaviour
{
    [SerializeField]
    private float _visibilitySpeed = 0.2f;
    public bool HasToFade;
    private TextMeshProUGUI _text;
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        if (HasToFade && _text.alpha >= 0.0f)
        {            
            _text.alpha -= _visibilitySpeed * Time.deltaTime;
        }
        else if(_text.alpha <= 0.0f)
        {
            _text.gameObject.SetActive(false);
            _text.alpha = 1.0f;
        }
    }
}
