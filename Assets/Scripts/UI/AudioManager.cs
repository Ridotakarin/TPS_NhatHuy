using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource, sfxSource;
    
    

    [SerializeField] private AudioClip buttonClick,heal, reload,pick,unlock, 
        hurt, dead,jump,land, bullet,plasma, explosion, zomdead;

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
        GetVolume();
    }
    private void Update()
    {
        GetVolume();
    }

    public  void GetVolume()
    {
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
        Debug.Log("Music Volume: " + volume);
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSfxVolume(float volume)
    {
        Debug.Log("SFX Volume: " + volume);
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }
    

    public void PlaySFX(AudioClip sfx) => sfxSource.PlayOneShot(sfx);
    public void OnClick() => PlaySFX(buttonClick);
    public void OnReload() => PlaySFX(reload);
    public void OnHeal() => PlaySFX(heal);
    public void OnPickUP() => PlaySFX(pick);
    public void OnUnlock() => PlaySFX(unlock);
    public void GetHurt() => PlaySFX(hurt);
    public void IsDead() => PlaySFX(dead);
    public void Plasma() => PlaySFX(plasma);
    public void Jump() => PlaySFX(jump);
    public void Land() => PlaySFX(land);
    public void Explosion() => PlaySFX(explosion);
    public void Bullet() => PlaySFX(bullet);
    public void PlayBossMussic()
    {
        musicSource.Play();
    }
    public void ReturnMainMenu()
    {
        musicSource.Stop();
    }
    public void ZomDead() => PlaySFX(zomdead);


}