using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip tapClip;

    public void PlayTapSound()
    {
        if (sfxSource != null && tapClip != null)
        {
            sfxSource.PlayOneShot(tapClip);
        }
    }
}
