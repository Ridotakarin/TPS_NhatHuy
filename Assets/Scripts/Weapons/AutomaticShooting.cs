using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Collections;

// Lớp cho súng tự động, kế thừa từ Shooting
public class AutomaticShooting : Shooting
{
    [SerializeField] private InputActionReference _shootAction;
    [SerializeField] private float _cooldown;
    [SerializeField] private Animator _animator;
    

    private float _lastShotTime;

    // Constructor để khởi tạo các giá trị
    private void Awake()
    {
        _animator = GameObject.FindAnyObjectByType<ThirdPersonController>().GetComponent<Animator>();
        // Số đạn mặc định
        maxAmmoInClip = 40;
        currentAmmo = maxAmmoInClip;
        // Số băng đạn dự trữ
        totalClips = 5;
        // Thời gian nạp đạn
        reloadTime = 3f;
    }
    

    private void Update()
    {
        // Kiểm tra xem nút bắn có được nhấn và có thể bắn không
        if (_shootAction.action.IsPressed() && FinishCooldown() && currentAmmo > 0 && !isReloading)
        {
            Shoot();
            _lastShotTime = Time.time;
            currentAmmo--;
            currentAmmoInClip = currentAmmo;
        }
        // Kiểm tra và tự động nạp đạn khi hết đạn
        CheckAndReload();
        UpdateText();
    }

    private bool FinishCooldown() => Time.time - _lastShotTime >= _cooldown;

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
            Debug.Log("Bắt đầu nạp đạn (súng tự động)...");
            // Kích hoạt animation reload ở đây
            // animator.SetTrigger("Reload");
            StartCoroutine(ReloadCoroutine());
        }
    }

    // Coroutine để xử lý thời gian nạp đạn
    private IEnumerator ReloadCoroutine()
    {
        _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
        _animator.SetBool("Reload",true);
        yield return new WaitForSeconds(reloadTime);
        _animator.SetBool("Reload",false);
        // Nạp đạn xong, cập nhật số đạn
        currentAmmo = maxAmmoInClip;
        totalClips--;
        isReloading = false;
        Debug.Log("Nạp đạn xong! Đạn hiện tại: " + currentAmmo + ", Băng đạn dự trữ: " + totalClips);
    }
    public override void UpdateText()
    {
        ammoText.text = "Ammo: "+currentAmmo.ToString();
        magazineText.text = "Magazine: "+totalClips.ToString();
    }
}
