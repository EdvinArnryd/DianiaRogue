using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool _isPaused = false;

    [SerializeField] private GameObject _pausePanel;

    public bool IsPaused => _isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0f;
            _pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            _pausePanel.SetActive(false);
        }
    }
}
