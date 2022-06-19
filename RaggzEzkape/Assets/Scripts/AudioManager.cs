using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public void ChangeMusic(AudioClip clip){
        music.Stop();
        music.clip = clip;
        music.Play();
    }
}
