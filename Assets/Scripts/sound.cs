// using UnityEngine.Audio;  // to access the AudioSource component 
using UnityEngine;

[System.Serializable]  // if we make a Custom Class  and want it to be able to be seen in the inspector e have to make is Serializable  
public class sound {

    public string name;     
   public AudioClip clip;
   [Range(0 , 1f)]
   public float volume;
   [Range(.1f , 3f)]
   public float pitch;

    public bool loop;

    public AudioSource source;





}//class