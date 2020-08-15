using UnityEngine;

public class AudioEndLevel : MonoBehaviour
{
    [SerializeField] private AudioClip loseClip;
    [SerializeField] private AudioClip winClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(bool value)
    {
        if (value)
            SetMusic(winClip);
        else
            SetMusic(loseClip);
    }

    private void SetMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
