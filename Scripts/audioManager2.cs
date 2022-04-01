using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audioManager2 : MonoBehaviour
{
    public sound[] gameSounds;

    public static audioManager2 instance;


    void Awake()
    {
        /*if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);*/


        foreach (sound s in gameSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.pitch = s.pitch;

            s.source.loop = s.loop;

            Play(s.name);


        }


        if (PlayerPrefs.GetInt("isMusicOff") == 1)
        {
            musicOff();
        }
        else
        {
            musicOn();
        }


    }



    public void Play(string name)
    {
        sound s = Array.Find(gameSounds, sound => sound.name == name);
        s.source.Play();
    }


    public void musicOff()
    {
        foreach (sound s in gameSounds)
        {
            s.source.volume = 0f;
        }
    }

    public void musicOn()
    {
        foreach (sound s in gameSounds)
        {
            s.source.volume = s.volume;
        }

    }


}
