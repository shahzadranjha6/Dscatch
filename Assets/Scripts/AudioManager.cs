using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;


    AudioSource audioSource;
    public AudioClip DiamondCollectSound;
    bool isplaying = false;

    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();  //-- get the audio source component
        
    }

   
    public void PlaySound() 
    {
        audioSource.PlayOneShot(DiamondCollectSound);
    }
    public void PlayBackgroundSound() 
    {
        if(audioSource.mute)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }

       
    } 
}
