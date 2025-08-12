using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class AntiCameraBlock : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    private InputSettingScript inputSettings;

    private void Awake()
    {
        inputSettings = GetComponent<InputSettingScript>();
    }

    private void Update()
    {
        if (inputSettings.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);

        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
        }
    }
}
