using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Collections;

// Lớp cho súng bán tự động, kế thừa từ Shooting
public class ManualShooting : Shooting
{
    [SerializeField] private InputActionReference _shootAction;
    [SerializeField] private Animator _animator;

    private InputSettingScript inputSettings;
    // Constructor để khởi tạo các giá trị
    private void Awake()
    {
        _animator = GameObject.FindAnyObjectByType<ThirdPersonController>().GetComponent<Animator>();
        inputSettings = GameObject.FindAnyObjectByType<InputSettingScript>();


        // Số đạn mặc định
        maxAmmoInClip = 1;
        currentAmmo = maxAmmoInClip;
        // Số băng đạn dự trữ
        totalClips = 10;
        // Thời gian nạp đạn
        reloadTime = 3f;
        totalAmmo = maxAmmoInClip * totalClips ;

        UpdateText();

    }

    private void Update()
    {
        if (_shootAction.action.triggered && currentAmmo > 0 && !isReloading && inputSettings.aiming)
        {
            Shoot();
            currentAmmo--;
            currentAmmoInClip = currentAmmo;
            UpdateText();
        }

        if (currentAmmo < maxAmmoInClip)
        {
            if (inputSettings.reload && !isReloading && totalAmmo > 0)
            {
                Reload();
            }
        }
        else inputSettings.reload = false;

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
        if (totalAmmo > 0 && !isReloading)
        {
            isReloading = true;
            Debug.Log("Bắt đầu nạp đạn (súng bán tự động)...");
            // Kích hoạt animation reload ở đây
            _animator.SetBool("Reload", true);
            StartCoroutine(ReloadCoroutine());
        }
        else if (totalAmmo <= 0)
        {
            Debug.Log("Hết đạn dự trữ!");
        }
        inputSettings.reload = false;
    }

    // Coroutine để xử lý thời gian nạp đạn
    private IEnumerator ReloadCoroutine()
    {
        _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
        yield return new WaitForSeconds(reloadTime);
        _animator.SetBool("Reload", false);


        nextAmmo = maxAmmoInClip - currentAmmo;
        currentAmmo = nextAmmo;
        totalAmmo -= nextAmmo;
        totalClips--;


        isReloading = false;
        // Gán giá trị vào biến public
        currentAmmoInClip = currentAmmo;
        UpdateText(); // <-- Gọi UpdateText() sau khi nạp đạn xong
    }
    public override void UpdateText()
    {
        ammoText.text = "Ammo: " + currentAmmoInClip.ToString();
        magazineText.text = "Total: " + totalAmmo.ToString();
    }
}
