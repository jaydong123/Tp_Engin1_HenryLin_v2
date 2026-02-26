using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip damagedSound;
    [SerializeField] private AudioClip swordHitSound;
    [SerializeField] private AudioMixer audioMixer;
    
    [Header("BGM")]
    [SerializeField] private AudioClip bgm;

    private void Awake()
    {
        if (!audioMixer)
            audioMixer = GetComponent<AudioMixer>();
    }
    
    public void PlayBGM(AudioSource audioSource)
    {
        //if (audioSource.isPlaying)
            //return;
        audioSource.clip = bgm;
        audioSource.loop = true;
        audioSource.Play();
    }
    
    public void PlayEntityDamagedSound(Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(damagedSound, position, volume);
    }
    
    public void PlayEntitySwordHitSound(AudioSource audioSource)
    {
        audioSource.clip = damagedSound;
        audioSource.PlayOneShot(damagedSound);
    }
    
    public void SetMasterVolumeSFX(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
    }
}
