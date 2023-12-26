using UnityEngine;
using UnityEngine.UI;

public class HY_AudioManager : MonoBehaviour
{
    public static HY_AudioManager instance;
    [SerializeField]
    AudioSource bgAudioSource,forOnShotPlayAudioSource;
    [SerializeField]
    AudioClip[] bgClips;
   [SerializeField] Slider musicSlider,sfxSlider;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        int rndIndex=Random.Range(0, bgClips.Length);
        StartBackgroundMusic(bgClips[rndIndex]);
        musicSlider.value = 0.3f;
        sfxSlider.value = 0.3f;
    }

    void StartBackgroundMusic(AudioClip BackgroundClip)
    {
        bgAudioSource.clip = BackgroundClip;
        bgAudioSource.Play();
    }
    private void Update()
    {
        bgAudioSource.volume = musicSlider.value;
        forOnShotPlayAudioSource.volume = sfxSlider.value;
    }
    public void PlayAudioEffectOnce(AudioClip effectClip)
    {
        forOnShotPlayAudioSource.PlayOneShot(effectClip);
    }
}
