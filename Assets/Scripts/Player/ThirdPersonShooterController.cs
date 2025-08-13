using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera aimVirtualCamera;
    [SerializeField] private float nomalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private float transitionSpeed = 10f; // Tốc độ chuyển đổi

    [SerializeField]private ThirdPersonController thirdPersonController;

    private InputSettingScript inputSettings;
    // Tham chiếu đến Cinemachine Third Person Aim
    private CinemachineCameraOffset offsetAim;
    private CinemachineHardLookAt aimCamera;
    
    private float targetFov;
    private void Awake()
    {
        inputSettings = GetComponent<InputSettingScript>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        aimVirtualCamera = GameObject.FindAnyObjectByType<CinemachineCamera>();
        offsetAim = aimVirtualCamera.GetComponent<CinemachineCameraOffset>();

    }

    private void Update()
    {
        // Kiểm tra chế độ ngắm
        if (inputSettings.aiming)
        {
            offsetAim.enabled = true;
            targetFov = 20f; // Đặt FieldOfView mục tiêu khi ngắm
            thirdPersonController.SetSensitivity(aimSensitivity);

        }
        else
        {
            offsetAim.enabled=false;
            targetFov = 40f; // Đặt FieldOfView mục tiêu khi bình thường
            thirdPersonController.SetSensitivity(nomalSensitivity);

        }


        // Chuyển đổi FieldOfView mượt mà
        aimVirtualCamera.Lens.FieldOfView = Mathf.Lerp(aimVirtualCamera.Lens.FieldOfView, targetFov, Time.deltaTime * transitionSpeed);
        // Bật ngắm
        
    }
}
