using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound // creating a class that is just to store sounds
{
    public string Name; // this will be the name of our audio clip 

    public AudioClip Clip; // this is the audio clip that will be played

    [Range(0f,1f)]
    public float Volume; // this will manage how loud or soft a clip will be

    [Range(.1f,3f)]
    public float Pitch; // this will manage the pitch of our clip

    public bool Loop; // this will manage wheather the sound loops or not



    [HideInInspector]
    public AudioSource Source; // this will track the audio source of the clip we create

}
