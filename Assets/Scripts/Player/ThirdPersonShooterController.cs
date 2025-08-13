using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera aimVirtualCamera;
    [SerializeField] private float nomalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private float transitionSpeed = 10f; // Tốc độ chuyển đổi
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject crossHair;

    [SerializeField] private ThirdPersonController thirdPersonController;

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
        crossHair = GameObject.Find("CrossHair");

    }

    private void Update()
    {
        MouseAim();
    }
    
    private void MouseAim()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        // Bắn tia từ camera qua con trỏ chuột để lấy vị trí mục tiêu
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        // Tạo một lớp layer mask cho các đối tượng mà tia ngắm có thể va chạm
        

        if (Physics.Raycast(ray, out RaycastHit hit, 999f, layerMask))
        {
            mouseWorldPosition = hit.point;
        }

        // Kiểm tra chế độ ngắm
        if (inputSettings.aiming)
        {
            // Điều chỉnh hướng nhìn của character
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
            crossHair.SetActive(true);
            // Cấu hình Cinemachine
            // offsetAim.enabled = true; // Bạn có thể tắt cái này nếu muốn dùng logic offset trực tiếp
            // Điều chỉnh FOV camera khi ngắm
            aimVirtualCamera.Lens.FieldOfView = Mathf.Lerp(aimVirtualCamera.Lens.FieldOfView, 20f, Time.deltaTime * transitionSpeed);
            thirdPersonController.SetSensitivity(aimSensitivity);

        }
        else
        {
            // Tắt các tính năng ngắm
            // offsetAim.enabled = false;
            // Chỉnh FOV camera về bình thường
            aimVirtualCamera.Lens.FieldOfView = Mathf.Lerp(aimVirtualCamera.Lens.FieldOfView, 40f, Time.deltaTime * transitionSpeed);
            thirdPersonController.SetSensitivity(nomalSensitivity);
            crossHair.SetActive(false);
        }
    }
}

