using UnityEngine;
using UnityEngine.UI;

public class UI_Gun : MonoBehaviour
{
    // Cần gán tham chiếu trong Inspector
    [SerializeField] private ThirdPersonShooterController _playerShooterController;
    [SerializeField] private Text _ammoText;
    [SerializeField] private Text _magazineText;

    private AutomaticShooting _currentAutomaticGun;
    private ManualShooting _currentManualGun;

    void Start()
    {
        // Kiểm tra xem _playerShooterController có tồn tại không
        if (_playerShooterController != null)
        {
            // Đăng ký lắng nghe sự kiện OnGunSwitched
            _playerShooterController.OnGunSwitched.AddListener(OnGunSwitched);
        }
        else
        {
            Debug.LogError("PlayerShooterController not assigned in UI_Gun.cs!");
        }
    }

    void Update()
    {
        // Cập nhật text liên tục trong Update để hiển thị số đạn thay đổi
        UpdateGunText();
    }

    // Phương thức này được gọi khi sự kiện OnGunSwitched kích hoạt
    private void OnGunSwitched(GameObject newGun)
    {
        // Lấy component của súng mới
        _currentAutomaticGun = newGun.GetComponent<AutomaticShooting>();
        _currentManualGun = newGun.GetComponent<ManualShooting>();

        // Cập nhật UI ngay lập tức khi súng được chuyển
        UpdateGunText();
    }

    private void UpdateGunText()
    {
        if (_currentAutomaticGun != null)
        {
            _ammoText.text = _currentAutomaticGun.currentAmmoInClip.ToString();
            _magazineText.text = _currentAutomaticGun.totalClips.ToString();
        }
        else if (_currentManualGun != null)
        {
            
            _ammoText.text = _currentManualGun.currentAmmoInClip.ToString();
            _magazineText.text = _currentManualGun.totalClips.ToString();
        }
        
    }
}
