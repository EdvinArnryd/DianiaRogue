using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float _xp = 0;
    [SerializeField] private float _xpThreshold = 5;
    [SerializeField] private float _xpThresholdMultiplier = 1.5f;
    private int _level = 1;

    [SerializeField] private TMP_Text _textLevel;

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
        if (_xp >= _xpThreshold)
        {
            _level++;
            _xpThreshold *= _xpThresholdMultiplier;
            SetLevelText();
        }
    }
}
