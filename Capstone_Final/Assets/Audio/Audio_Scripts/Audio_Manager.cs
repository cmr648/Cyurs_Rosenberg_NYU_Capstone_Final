using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; // This script will use audio components
using System;

public class Audio_Manager : MonoBehaviour
{
    public Sound[] Sounds; // this will manage a a list of sound classes within our audio manager script

   

    // Start is called before the first frame update
    void Awake()
    {
       foreach(Sound New_Sound in Sounds) // going through all of our sounds
        {
            New_Sound.Source = gameObject.AddComponent<AudioSource>();

            New_Sound.Source.clip = New_Sound.Clip; // setting our clip

            New_Sound.Source.volume = New_Sound.Volume;

            New_Sound.Source.pitch = New_Sound.Pitch;

            New_Sound.Source.loop = New_Sound.Loop;



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play_Sound(string Clip)
    {
        Sound Sound_To_Play = Array.Find(Sounds, Sound => Sound.Name == Clip);

        if(Sound_To_Play == null)
        {
            Debug.Log("Sound " + Clip + " Not Found"); // creating an error message for ourselves
            return;
        }

        Sound_To_Play.Source.Play();
    }

    public void Play_Loop_Sound(string Clip)
    {
        Sound Sound_To_Play = Array.Find(Sounds, Sound => Sound.Name == Clip);

        if (Sound_To_Play == null)
        {
            Debug.Log("Sound " + Clip + " Not Found"); // creating an error message for ourselves
            return;
        }
        if (!Sound_To_Play.Source.isPlaying)
        {
            Sound_To_Play.Source.Play();
        }
       
    }

    public void Pause_Sound(string Clip) // a void to stop a sound we are playing especially if it is a looping sound
    {
        Sound Sound_To_Play = Array.Find(Sounds, Sound => Sound.Name == Clip);

        if (Sound_To_Play == null)
        {
            Debug.Log("Sound " + Clip + " Not Found"); // creating an error message for ourselves
            return;
        }

        Sound_To_Play.Source.Pause();
    }





    public void Set_Audio_Track(string Clip,AudioClip Clip_To_Set) // creating a function with a sound name and clip to set
    {
        Sound Audio_Source_To_Choose = Array.Find(Sounds, Sound => Sound.Name == Clip); // finding the audiosource of our clip name

        Audio_Source_To_Choose.Clip = Clip_To_Set; // setting a specific clip to that audio source
        
    }



}
