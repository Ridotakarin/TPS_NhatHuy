using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip buttonClick, fireSFX,missile,heal, destroy;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // Tải dữ liệu âm thanh từ player pref lên
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            sfxSource.volume = PlayerPrefs.GetFloat("SfxVolume");
        }
    }
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSfxVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }
    public void PlaySFX(AudioClip sfx) => sfxSource.PlayOneShot(sfx);
    public void OnFire() => PlaySFX(fireSFX);
    public void OnMissile() => PlaySFX(missile);
    public void OnClick() => PlaySFX(buttonClick);
    public void OnDestroyed() => PlaySFX(destroy);
    public void OnHeal() => PlaySFX(heal);
}