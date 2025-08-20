using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHealth : MonoBehaviour
{
    [SerializeField] private ThirdPersonController _thirdPersonController;
    [SerializeField] private PlayerData _playerHealth;
    [SerializeField] private Text _health;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private InputSettingScript inputSettings;



    private void Start()
    {
        if (_thirdPersonController == null)
        {
            _thirdPersonController = GameObject.Find("Space_Solider").GetComponent<ThirdPersonController>();
        }
        if (_playerHealth == null)
        {
            _playerHealth = GameObject.Find("Space_Solider").GetComponent<PlayerData>();
        }
        settingPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        tutorialPanel.SetActive(true);
        
    }

    private void Update()
    {
        if (_playerHealth != null)
        {
            _health.text = _playerHealth.CurrentHealth.ToString() + "/100 ";

        }
        CloseTutorial();
        if(Input.GetKey(KeyCode.Escape))
        {
            OpenSettings();
        }
        
    }
    
    public void CloseTutorial()
    {
        if(Input.GetKey(KeyCode.Return)||Input.GetKey(KeyCode.KeypadEnter))
        {
            tutorialPanel.SetActive(false);
        }
    }
    public void OpenSettings()
    {
        settingPanel.SetActive(true);
        gameoverPanel.SetActive(false);
        inputSettings.cursorLocked = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void CloseSettings()
    {
        settingPanel.SetActive(false);
        inputSettings.cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    public void GameOverPanel()
    {
        settingPanel.SetActive(false);
        gameoverPanel.SetActive(true);
        inputSettings.cursorLocked = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}