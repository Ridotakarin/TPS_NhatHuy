using UnityEngine;
using UnityEngine.Events;

// Đây là lớp cơ sở cho tất cả các loại súng
public abstract class Shooting : MonoBehaviour
{
    // Sự kiện được gọi khi súng bắn
    public UnityEvent OnShoot;

    // Các thuộc tính chung cho tất cả các loại súng
    [Header("Ammo Settings")]
    [Tooltip("Số đạn tối đa trong một băng")]
    public int maxAmmoInClip;
    [Tooltip("Số băng đạn dự trữ")]
    public int totalClips;
    [Tooltip("Thời gian để nạp đạn")]
    public float reloadTime;

    // Biến private để theo dõi số đạn hiện tại
    protected int currentAmmo;

    // Biến private để theo dõi trạng thái nạp đạn
    protected bool isReloading = false;

    // Phương thức ảo để bắn, sẽ được ghi đè bởi các lớp con
    public abstract void Shoot();

    // Phương thức ảo để nạp đạn, sẽ được ghi đè bởi các lớp con
    public abstract void Reload();

    // Phương thức để kiểm tra và nạp đạn khi hết đạn
    protected void CheckAndReload()
    {
        // Nếu hết đạn và chưa đang nạp đạn, bắt đầu nạp
        if (currentAmmo <= 0 && !isReloading && totalClips > 0)
        {

            Reload();
        }
    }
}
