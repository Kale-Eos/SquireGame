using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]               // System instantiates components 
public class Sound
{
    public string name;             // Custom name of element
    public AudioClip clip;          // insert audio clip
    [Range(0f, 1f)]                 // range of volume from 0-100%
    public float volume = 1f;       // auto set to 100%
    [Range(0.1f, 3f)]               // range of sound speed from 10-300%
    public float pitch = 1f;        // auto set to 100%
    [Range(0f, 0.5f)]               // range of 0-50% fluctuation
    public float RandomVolume;      // randomizes sound volume
    [Range(0f, 0.5f)]               // range of 0-50% fluctuation
    public float RandomPitch;       // randomizes sound speed
    public bool loop = false;       // option for looping

    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;           // source placement
        source.clip = clip;         // clip placement
        source.loop = loop;         // loop placement
    }

    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-RandomVolume / 2f, RandomVolume / 2f));     // volume control with random volume fluctuation
        source.pitch = pitch * (1 + Random.Range(-RandomPitch / 2f, RandomPitch / 2f));         // pitch control with random pitch fluctuation 

        source.Play();                                                                          // plays sound
    }

    public void Stop()
    {
        source.Stop();              // stops sound
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;    // identifies AudioManager

    [SerializeField]                        // instantiates field
    Sound[] sounds;                         // instantiates Sound array

    void Awake()
    {
        // For editor's log
        if (instance != null)
        {
            Debug.LogError("More than one AudioManager in scene.");
            if (instance != null)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)                                        // any audible sound of increasing order
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);       // creates temp gameobject of music
            _go.transform.SetParent(this.transform);                                    // as a child
            sounds[i].SetSource(_go.AddComponent<AudioSource>());                       // and of specific sound played
        }

        PlaySound("Music");
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)     // any audible sound of increasing order
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();                   // plays sound
                return;                             // loops yo
            }
        }
    }

    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)     // any audible sound of increasing order
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();                   // stops sound
                return;                             // loops yo
            }
        }

        // No Sound Warning
        Debug.LogWarning("AudioManager: Sound ~" + _name + "~ not found in library");

        StopSound("Music");
        StopSound("Tutorial_BGM");
        StopSound("Level1_BGM");
        StopSound("Level2_BGM");
    }
}