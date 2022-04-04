using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObject : MonoBehaviour
{
    public AudioSource source;
    public AudioClip current;

    public void PlayMusic(AudioClip mus)
    {
        if(mus == current)
        {
            return;
        }

        if(mus != current)
        {
            source.clip = mus;
            source.Play();
        }
    }

    public void StopMusic()
    {
        source.Stop();
    }
}
