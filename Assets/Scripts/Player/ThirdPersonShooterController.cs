using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineThirdPersonFollow aimVirtualCamera;
    [SerializeField] private float nomalSensitivity;
    [SerializeField] private float aimSensitivity;

    private ThirdPersonController thirdPersonController;
    private InputSettingScript inputSettings;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        inputSettings = GetComponent<InputSettingScript>();
    }

    private void Update()
    {
        if (inputSettings.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);

        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(nomalSensitivity);
        }
    }
}
