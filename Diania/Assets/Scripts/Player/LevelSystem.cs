using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float _xp = 0;
    [SerializeField] private float _xpThreshold = 5;
    [SerializeField] private float _xpThresholdMultiplier = 1.5f;
    private int _level = 1;

    public void GainExp(float xpAmount)
    {
        _xp += xpAmount;
        if(_xp >= _xpThreshold)
        {
            _level++;
            _xpThreshold *= _xpThresholdMultiplier;
        }
    }
}
