
using UnityEngine.Audio;  // to access the AudioSource component 
using UnityEngine;
using System;

public class AudioManager_Script : MonoBehaviour
{

    public sound[] sounds;  // sound is a class

    public static AudioManager_Script instance;  // to access the AudioManager_Script from other scripts

    // Awake is called before the Start function.
    void Awake()
    {
        if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        else
            {
                Destroy(gameObject);
                return;
            }

            
    }

    void Start(){

        Debug.Log("in start of AudioManager_Script");
        
        
        foreach (sound s in sounds)
            {
               s.source = gameObject.AddComponent<AudioSource>();
               s.source.clip = s.clip;

               s.source.volume = s.volume;
               s.source.pitch = s.pitch; 
                s.source.loop = s.loop;
            }

        Play("theme");
    }

    // we will cal this function From outside the Class
    public void Play(string name)
        {
            sound s = Array.Find(sounds, sound => sound.name == name);

                if (s != null)
                {
                    Debug.Log("Sound found: " + name);
                    s.source.Play();
                }
                else
                {
                    Debug.LogError("Sound not found: " + name);
                }

            Debug.Log(s);
            s.source.Play();



            // s.source.PlayOneShot(s.source.clip);
        }


    public void MuteMusic()
        {
            foreach (sound s in sounds)
                {
                    if (s.name == "theme")
                       s.source.Stop();
                }
        }

    public void UnMuteMusic()
        {
            foreach (sound s in sounds)
                {
                    if (s.name == "theme")
                       s.source.Play();
                }
        }



}//class