using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public Sound[] SoundList;

    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }

        foreach(Sound s in SoundList)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(SoundList, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound Not Found");
            return;
        }

        s.source.volume = s.volume;
        s.source.Play();
    }

    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(SoundList, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound Not Found");
            return;
        }

        s.source.PlayOneShot(s.sound, s.volume);
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(SoundList, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound Not Found");
            return;
        }

        s.source.Stop();
    }
}