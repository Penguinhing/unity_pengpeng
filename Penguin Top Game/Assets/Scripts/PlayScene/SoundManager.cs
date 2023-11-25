using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] sounds;
    public static SoundManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        sounds = GetComponents<AudioSource>();
    }

    private AudioSource FindSound(string name)
    {
        for (int i = 0; i < sounds.Length; ++i)
        {
            if (sounds[i].clip.name == name)
            {
                return sounds[i];
            }
        }
        return null;
    }




    public void PlayBirdClickSound()
    {
        FindSound("bird_click_1").Play();
    }

    public void PlayPlusSound()
    {
        FindSound("plus").Play();
    }

    public void PlayGameOverSound()
    {
        FindSound("background").Stop();
        FindSound("gameover").Play();
    }

    public void PlaySpeedUpSound()
    {
        FindSound("speedup").Play();
    }



}
