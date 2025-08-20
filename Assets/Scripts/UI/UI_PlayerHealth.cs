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
    }

    private void Update()
    {
        if (_playerHealth != null)
        {
            _health.text = _playerHealth.CurrentHealth.ToString() + "/100 ";

        }
        
    }
}