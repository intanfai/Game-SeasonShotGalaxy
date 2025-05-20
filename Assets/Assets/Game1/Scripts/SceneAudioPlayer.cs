using UnityEngine;

public class SceneAudioPlayer : MonoBehaviour
{
    private void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}