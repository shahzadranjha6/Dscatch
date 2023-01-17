using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip DiamondCollectSound;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   
    public void PlaySound() 
    {
        audioSource.PlayOneShot(DiamondCollectSound);
    } 
}
