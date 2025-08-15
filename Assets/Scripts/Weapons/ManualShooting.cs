using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Collections;

// Lớp cho súng bán tự động, kế thừa từ Shooting
public class ManualShooting : Shooting
{
    [SerializeField] private InputActionReference _shootAction;
    [SerializeField] private Animator _animator;


    // Constructor để khởi tạo các giá trị
    private void Awake()
    {
        _animator = GameObject.FindAnyObjectByType<ThirdPersonController>().GetComponent<Animator>();

        // Số đạn mặc định
        maxAmmoInClip = 1;
        currentAmmo = maxAmmoInClip;
        // Số băng đạn dự trữ
        totalClips = 5;
        // Thời gian nạp đạn
        reloadTime = 3f;

    }

    private void Update()
    {
        // Bắn khi nút được nhấn
        if (_shootAction.action.triggered && currentAmmo > 0 && !isReloading)
        {
            Shoot();
            currentAmmo--;
            currentAmmoInClip = currentAmmo;
        }
        // Kiểm tra và tự động nạp đạn khi hết đạn
        CheckAndReload();
    }

    // Ghi đè phương thức Shoot()
    public override void Shoot()
    {
        OnShoot.Invoke();
    }

    // Ghi đè phương thức Reload()
    public override void Reload()
    {
        // Nếu có băng đạn dự trữ và chưa đang nạp, bắt đầu nạp
        if (totalClips > 0 && !isReloading)
        {
            isReloading = true;
            Debug.Log("Bắt đầu nạp đạn (súng bán tự động)...");
            // Kích hoạt animation reload ở đây
            _animator.SetBool("Reload", true);
            StartCoroutine(ReloadCoroutine());
        }
        else if (totalClips <= 0)
        {
            Debug.Log("Hết đạn dự trữ!");
        }
    }

    // Coroutine để xử lý thời gian nạp đạn
    private IEnumerator ReloadCoroutine()
    {
        _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
        yield return new WaitForSeconds(reloadTime);
        _animator.SetBool("Reload", false);

        // Nạp đạn xong, cập nhật số đạn
        currentAmmo = maxAmmoInClip;
        totalClips--;
        isReloading = false;
        Debug.Log("Nạp đạn xong! Đạn hiện tại: " + currentAmmo + ", Băng đạn dự trữ: " + totalClips);
    }
    public override void UpdateText()
    {
        ammoText.text = "Ammo: " + currentAmmo.ToString();
        magazineText.text = "Magazine: " + totalClips.ToString();
    }
}
