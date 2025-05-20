using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource audioSource;   // Drag AudioSource dari GameObject
    public AudioClip winClip;         // Drag file audio "win"
    public AudioClip loseClip;        // Drag file audio "lose"

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winClip);
    }

    public void PlayLoseSound()
    {
        audioSource.PlayOneShot(loseClip);
    }
}
