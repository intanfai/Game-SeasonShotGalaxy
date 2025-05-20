using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundPlayer : MonoBehaviour
{
    public GameObject FadeOutPanel;

    public void FadeOut()
    {
        if (FadeOutPanel != null)
            FadeOutPanel.SetActive(true);
    }
    
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
