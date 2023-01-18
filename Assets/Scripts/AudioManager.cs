using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;


    AudioSource audioSource;
    public AudioClip DiamondCollectSound;

    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();  //-- get the audio source component
    }

   
    public void PlaySound() 
    {
        audioSource.PlayOneShot(DiamondCollectSound);
    } 
}
