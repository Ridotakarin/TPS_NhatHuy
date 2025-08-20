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
    private InputSettingScript inputSettings;


    private float _lastShotTime;

    // Constructor để khởi tạo các giá trị
    private void Awake()
    {
        _animator = GameObject.FindAnyObjectByType<ThirdPersonController>().GetComponent<Animator>();
        inputSettings = GameObject.FindAnyObjectByType<InputSettingScript>();
        
        ReloadAmmo();
        
    }


    private void Update()
    {
        if (_shootAction.action.IsPressed() && FinishCooldown() && currentAmmo > 0 && !isReloading && inputSettings.aiming)
        {
            Shoot();
            _lastShotTime = Time.time;
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

    private bool FinishCooldown() => Time.time - _lastShotTime >= _cooldown;

    // Ghi đè phương thức Shoot()
    public override void Shoot()
    {
        AudioManager.Instance.Bullet();
        OnShoot.Invoke();
    }

    // Ghi đè phương thức Reload()
    public override void Reload()
    {
        // Nếu có băng đạn dự trữ và chưa đang nạp, bắt đầu nạp
        if (totalAmmo > 0 && !isReloading)
        {
            isReloading = true;
            Debug.Log("Bắt đầu nạp đạn (súng tự động)...");
            // Kích hoạt animation reload ở đây
            // animator.SetTrigger("Reload");
            StartCoroutine(ReloadCoroutine());
        }
        inputSettings.reload = false;

    }

    // Coroutine để xử lý thời gian nạp đạn
    private IEnumerator ReloadCoroutine()
    {
        _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
        _animator.SetBool("Reload", true);
        AudioManager.Instance.OnReload();
        yield return new WaitForSeconds(reloadTime);
        _animator.SetBool("Reload", false);


        nextAmmo = maxAmmoInClip - currentAmmo;

        if(totalAmmo >= nextAmmo)
        {
            currentAmmo += nextAmmo;
            totalAmmo -= nextAmmo;
        }
        else
        {
            currentAmmo += totalAmmo;
            totalAmmo -= totalAmmo;
        }



        totalClips--;

        isReloading = false;    
        currentAmmoInClip = currentAmmo; 

        UpdateText(); // <-- Gọi khi nạp đạn xong
    }

    public override void UpdateText()
    {
        ammoText.text = "Ammo: "+currentAmmo.ToString();
        magazineText.text = "Total: " + totalAmmo.ToString();
    }
    public override void ReloadAmmo()
    {
        // Số đạn mặc định
        maxAmmoInClip = 40;
        currentAmmo = maxAmmoInClip;
        
        // Số băng đạn dự trữ
        totalClips = 5;
        // Thời gian nạp đạn
        reloadTime = 3f;
        totalAmmo = maxAmmoInClip * totalClips;
        UpdateText();
    }
}
