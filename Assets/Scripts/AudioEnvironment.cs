using UnityEngine;

public class AudioEnvironment : MonoBehaviour
{
    private static AudioEnvironment Instance;
    [SerializeField] private AudioClip explosionClip;
    [SerializeField] private AudioClip shotClip;
    private AudioSource[] audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        audioSource = GetComponents<AudioSource>();
    }

    public static void ShotAudio()
    {
        Instance.audioSource[0].clip = Instance.shotClip;
        Instance.audioSource[0].Play();
    }

    public static void ExplosionAudio()
    {
        Instance.audioSource[1].clip = Instance.explosionClip;
        Instance.audioSource[1].Play();
    }
}
