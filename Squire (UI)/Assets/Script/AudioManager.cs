using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            gameObject.AddComponent<AudioSource>();
            gameObject.
        }
        
    }

}
