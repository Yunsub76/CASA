using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;
    public static SoundManager instance;
    public AudioClip[] bgmList;
    public AudioMixer mixer;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
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
    public void PlaySound(AudioClip clip)
    {
        GameObject soundGM = new GameObject("Sound");
        AudioSource audioSource = soundGM.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("PlaySound")[0];
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(soundGM, clip.length);
    }

    public void BGMSound(AudioClip clip)
    {
        bgm.outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0];
        bgm.clip = clip;
        bgm.loop = true;
        bgm.volume = 0.1f;
        bgm.Play();

    }

}
