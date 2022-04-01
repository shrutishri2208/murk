using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public sound[] gameSounds;

    void Awake()
    {
        foreach(sound s in gameSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.pitch = s.pitch;

            s.source.loop = s.loop;

        }
        if(PlayerPrefs.GetInt("isSoundOff") == 1)
        {
            soundOff();
        }
        else
        {
            soundOn();
        }

    }



    public void Play(string name)
    {
        sound s = Array.Find(gameSounds, sound => sound.name == name);
        s.source.Play();
    }


    public void soundOff()
    {
        foreach (sound s in gameSounds)
        {
            s.source.volume = 0f;
        }
    }

    public void soundOn()
    {
        foreach (sound s in gameSounds)
        {
            s.source.volume = s.volume;
        }
    }

}
