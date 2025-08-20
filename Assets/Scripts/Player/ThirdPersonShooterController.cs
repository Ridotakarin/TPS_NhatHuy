using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera aimVirtualCamera;
    [SerializeField] private float nomalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private float transitionSpeed = 10f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject crossHair;
    [SerializeField] private GameObject normalCH;
    [SerializeField] private GameObject powerCH;
    [SerializeField] private Material normalMats;
    [SerializeField] private Material powerMats;
    [SerializeField] private GameObject _aimLight;
    [SerializeField] private GameObject _flashLight;
    [SerializeField] private GameObject gun;


    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeField] private Animator animator;


    // =========================================================================
    [Header("Gun Switching")]
    [SerializeField] private GameObject _normalGun;
    [SerializeField] private GameObject _powerGun;

    [SerializeField] private Shooting _normalGunScript;
    [SerializeField] private Shooting _powerGunScript;
    private Shooting _currentGunScript;
    private bool _hasPowerGun = false;

    private SkinnedMeshRenderer _skinnedMeshRenderer;

    // UnityEvent để các script khác, như UI, có thể lắng nghe
    public UnityEvent<GameObject> OnGunSwitched;

    private InputSettingScript inputSettings;

    // Tham chiếu đến Cinemachine
    private CinemachineCameraOffset offsetAim;

    private float targetFov;

    private void Awake()
    {
        // Lấy các component từ các đối tượng đã được gán sẵn
        inputSettings = GetComponent<InputSettingScript>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
        aimVirtualCamera = GameObject.FindAnyObjectByType<CinemachineCamera>();

        if(gun!=null) _skinnedMeshRenderer = gun.GetComponent<SkinnedMeshRenderer>();

        _aimLight = GameObject.Find("Aim Light");
        _flashLight = GameObject.Find("Flash Light");


        if (aimVirtualCamera != null)
        {
            offsetAim = aimVirtualCamera.GetComponent<CinemachineCameraOffset>();
        }

        // Lấy các script Shooting từ GameObject súng
        if (_normalGun != null)
        {
            _normalGunScript = _normalGun.GetComponent<Shooting>();
            
        }
        if (_powerGun != null)
        {
            _powerGunScript = _powerGun.GetComponent<Shooting>();
        }

        
    }

    private void Start()
    {
        // Khởi tạo trạng thái súng ban đầu
        if (_normalGunScript != null)
        {
            _currentGunScript = _normalGunScript;
            _normalGun.SetActive(true);
            crossHair = normalCH;
            _normalGunScript.OnEquip();
        }
        if (_powerGunScript != null)
        {
            _powerGun.SetActive(false);
            _powerGunScript.OnUnequip();
        }

        if (OnGunSwitched != null)
        {
            OnGunSwitched.Invoke(_currentGunScript.gameObject);
        }

        ObtainPowerGun();
    }
    private void Update()
    {
        MouseAim();

        // Chuyển đổi súng bằng phím 1 và 2
        if (Input.GetKeyDown(KeyCode.Alpha1) && _currentGunScript != _normalGunScript)
        {
            SwitchGuns(_normalGunScript);
            crossHair = normalCH;
            _skinnedMeshRenderer.material = normalMats;


        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _hasPowerGun && _currentGunScript != _powerGunScript)
        {
            SwitchGuns(_powerGunScript);
            crossHair = powerCH;
            _skinnedMeshRenderer.material = powerMats;


        }
    }

    private void MouseAim()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        // Bắn tia từ camera qua con trỏ chuột để lấy vị trí mục tiêu
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, 999f, layerMask))
        {
            mouseWorldPosition = hit.point;
        }

        if (inputSettings.aiming)
        {
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            if (offsetAim != null)
            {
                offsetAim.enabled = true;
            }
            if (_aimLight != null)
            {
                _aimLight.SetActive(true);
            }
            if (_flashLight != null)
            {
                _flashLight.SetActive(false);
            }

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            if (crossHair != null)
            {
                crossHair.SetActive(true);
            }

            animator.SetBool("Aiming", true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            if (aimVirtualCamera != null)
            {
                aimVirtualCamera.Lens.FieldOfView = Mathf.Lerp(aimVirtualCamera.Lens.FieldOfView, 15f, Time.deltaTime * transitionSpeed);
            }
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotationOnMove(false);
        }
        else
        {
            if (offsetAim != null)
            {
                offsetAim.enabled = false;
            }

            if (aimVirtualCamera != null)
            {
                aimVirtualCamera.Lens.FieldOfView = Mathf.Lerp(aimVirtualCamera.Lens.FieldOfView, 40f, Time.deltaTime * transitionSpeed);
            }

            thirdPersonController.SetSensitivity(nomalSensitivity);
            thirdPersonController.SetRotationOnMove(true);

            if (crossHair != null)
            {
                crossHair.SetActive(false);
            }
            if (_aimLight != null)
            {
                _aimLight.SetActive(false);
            }
            if (_flashLight != null)
            {
                _flashLight.SetActive(true);
            }

            animator.SetBool("Aiming", false);
        }
    }

    private void SwitchGuns(Shooting newGunScript)
    {
        if (_currentGunScript == null) return;

        // Vô hiệu hóa súng cũ và dừng coroutine nạp đạn
        _currentGunScript.OnUnequip();
        _currentGunScript.gameObject.SetActive(false);

        // Trang bị súng mới
        _currentGunScript = newGunScript;
        if (_currentGunScript != null)
        {
            _currentGunScript.gameObject.SetActive(true);
            _currentGunScript.OnEquip();
        }

        // Kích hoạt sự kiện để UI cập nhật
        if (OnGunSwitched != null)
        {
            OnGunSwitched.Invoke(_currentGunScript.gameObject);
        }
    }

    public void ObtainPowerGun()
    {
        _hasPowerGun = true;
    }
}