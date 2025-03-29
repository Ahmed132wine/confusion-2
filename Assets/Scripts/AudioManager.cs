using UnityEngine;

public class audioManager : MonoBehaviour
{
    private static audioManager instance;

    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----Audio Clip-----")]
    public AudioClip background;
    public AudioClip jump;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip Clip)
    {
        SFXSource.PlayOneShot(Clip);
    }


   
}
