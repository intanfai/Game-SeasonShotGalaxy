using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource bgmSource;
    public AudioSource sfxSource; // untuk suara menang/kalah
    public AudioClip winClip;
    public AudioClip loseClip;

    void Awake()
    {
        // Singleton agar tidak dobel saat pindah scene
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // agar tidak hilang saat load scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayWinSound()
    {
        bgmSource.Stop();           // hentikan backsound utama
        sfxSource.clip = winClip;
        sfxSource.Play();
    }

    public void PlayLoseSound()
    {
        bgmSource.Stop();           // hentikan backsound utama
        sfxSource.clip = loseClip;
        sfxSource.Play();
    }

    public void StopAll()
    {
        bgmSource.Stop();
        sfxSource.Stop();
    }
}
