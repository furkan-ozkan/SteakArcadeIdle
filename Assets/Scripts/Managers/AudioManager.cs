using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public AudioData audioData;
    public void PlaySoundOneTime(AudioClip audio,float volume)
    {
        GameObject audioObject = new GameObject();
        AudioSource source = audioObject.AddComponent<AudioSource>();
        source.volume = volume;
        source.clip = audio;
        source.spatialBlend = Single.MaxValue;
        source.Play();
        StartCoroutine(DestroyAudioObject(audio.length,audioObject));
    }

    private IEnumerator DestroyAudioObject(float time, GameObject audioObject)
    {
        yield return new WaitForSeconds(time);
        Destroy(audioObject);
    }
}
