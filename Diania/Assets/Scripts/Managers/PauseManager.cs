using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private bool _isPaused = false;

    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _deathMenu;
    [SerializeField] private GameObject _levelUpMenu;
    [SerializeField] private Player _player;
    private Image _pausePanelImage;



    public bool IsPaused => _isPaused;

    private void Awake()
    {
        _player.OnPlayerDied += OnPlayerDiedHandler;
    }

    private void Start()
    {
        _pausePanelImage = _pausePanel.GetComponent<Image>();
    }

    private void OnDestroy()
    {
        _player.OnPlayerDied -= OnPlayerDiedHandler;
    }

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
            _pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            _pausePanel.SetActive(false);
            _pauseMenu.SetActive(false);
        }
    }

    private void OnPlayerDiedHandler()
    {
        if (!_isPaused)
        {
            TogglePause();
            _pausePanelImage.color = new Color(82, 15, 15, 52);
            _deathMenu.SetActive(true);
        }
    }

    private void OnPlayerLevelUpHandler()
    {
        if (!_isPaused)
        {
            TogglePause();
            _levelUpMenu.SetActive(true);
        }
    }
}
