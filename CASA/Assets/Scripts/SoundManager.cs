using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;
    public static SoundManager instance;
    public int bGMNumber=0;
    public AudioClip[] bgmList;
    public AudioClip[] sFXList;

    public AudioMixer mixer;

    public void Awake()
    {
       if (instance == null)
       {
           instance = this;
            DontDestroyOnLoad(instance);
            BGMSound();
       }
       else
       {
            Destroy(gameObject);
       }
    }
    
    public void BGMVolume(float volume)
    {
        mixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
    }

    public void SFXSound(AudioClip clip)
    {
        GameObject soundGM = new GameObject("SFX Sound");
        AudioSource audioSource = soundGM.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(soundGM, clip.length);
    }

    public void BGMSound()
    {
        bgm.outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0];
        bgm.clip = bgmList[bGMNumber];
        bgm.loop = true;
        bgm.volume = 1f;
        bgm.Play();
    }

}
