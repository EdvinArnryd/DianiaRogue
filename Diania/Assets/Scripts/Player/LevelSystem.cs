using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float _xp = 0;
    [SerializeField] private float _xpThreshold = 5;
    [SerializeField] private float _xpThresholdMultiplier = 2.5f;
    private int _level = 1;

    [SerializeField] private TMP_Text _textLevel;

    [SerializeField] private Slider _slider;

    [SerializeField] private PauseManager _pauseManager;

    public event Action OnLevelUp;

    void Start()
    {
        SetLevelText();
    }

    private void SetLevelText()
    {
        _textLevel.text = _level.ToString();
    }

    public void GainExp(float xpAmount)
    {
        _xp += xpAmount;
        print(_xp + " Threshold: " + _xpThreshold);
        UpdateProgressBar();
        if (_xp >= _xpThreshold)
        {
            OnLevelUp?.Invoke();
            _xp -= _xpThreshold;
            _level++;
            _xpThreshold *= _xpThresholdMultiplier;
            SetLevelText();
            _slider.value = 0;
        }
    }

    private void UpdateProgressBar()
    {
        _slider.value = _xp / _xpThreshold;
    }
}
