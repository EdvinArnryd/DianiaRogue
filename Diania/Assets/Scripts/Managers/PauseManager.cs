using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum MenuState
{
    None,
    EscapeMenu,
    DeathMenu,
    LevelUpMenu
}

public class PauseManager : MonoBehaviour
{
    private bool _isPaused = false;

    [Header("UI Elements")]
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _deathMenu;
    [SerializeField] private GameObject _levelUpMenu;
    [SerializeField] private TMP_Text _text;

    [Header("Class References")]
    [SerializeField] private Player _player;
    [SerializeField] private LevelSystem _levelSystem;

    private Image _pausePanelImage;

    private MenuState _currentMenuState = MenuState.None;

    public bool IsPaused => _isPaused;

    private void Awake()
    {
        _player.OnPlayerDied += OnPlayerDiedHandler;
        _levelSystem.OnLevelUp += OnPlayerLevelUpHandler;
    }

    private void Start()
    {
        _pausePanelImage = _pausePanel.GetComponent<Image>();
    }

    private void OnDestroy()
    {
        _player.OnPlayerDied -= OnPlayerDiedHandler;
        _levelSystem.OnLevelUp -= OnPlayerLevelUpHandler;
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
        if (_currentMenuState != MenuState.None && _currentMenuState != MenuState.EscapeMenu) return;
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0f;
            _pausePanel.SetActive(true);
            SetMenuState(MenuState.EscapeMenu);
        }
        else
        {
            UnPause();
        }
    }

    private void SetMenuState(MenuState state)
    {
        _isPaused = true;
        _currentMenuState = state;
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);

        _deathMenu.SetActive(false);
        _levelUpMenu.SetActive(false);
        _pauseMenu.SetActive(false);

        switch (_currentMenuState)
        {
            case MenuState.EscapeMenu:
                _pauseMenu.SetActive(true);
                _pausePanelImage.color = new Color(100f / 255f, 100f / 255f, 100f / 255f, 200f / 255f);
                _text.text = "Game Paused";
                _text.color = Color.black;
                break;
            case MenuState.DeathMenu:
                _deathMenu.SetActive(true);
                _pausePanelImage.color = new Color(126f / 255f, 35f / 255f, 35f / 255f, 200f / 255f);
                _text.text = "You Died!";
                _text.color = Color.red;
                break;
            case MenuState.LevelUpMenu:
                _levelUpMenu.SetActive(true);
                _pausePanelImage.color = new Color(51f / 255f, 63f / 255f, 100f / 255f, 200f / 255f);
                _text.text = "Level Up!";
                _text.color = Color.blue;
                break;
        }
    }

    private void OnPlayerDiedHandler()
    {
        SetMenuState(MenuState.DeathMenu);
    }

    private void OnPlayerLevelUpHandler()
    {
        SetMenuState(MenuState.LevelUpMenu);
    }

    public void UnPause()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
        _currentMenuState = MenuState.None;
    }

    public void ChestPickedUp()
    {
        
    }
}
