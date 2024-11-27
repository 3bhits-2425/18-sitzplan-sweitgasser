using System.Collections;

using System.Collections.Generic;

using UnityEngine;


// Klasse sound muss Serialisierbar sein


public class AudioManager : MonoBehaviour

{
    public AudioSource audiosSource;

    [SerializeField] private Sound[] sounds;

    //speichere eine Referenz zum Singleton

    private AudioManager singleton;


    void Awake()

    {

        //stelle sicher, dass nur ein Element vom Typ AudioManager erzeugt werden kann

        if (singleton == null)

        {

            //es existiert noch kein AudioManager --> erzeuge einen neuen

            singleton = this;

            //speichere die aktuelle Instanz im Singleton

        }

        else

        {

            //es existiert bereits ein AudioManager --> erzeuge keinen neuen --> zerstoere das aktuelle Objekt

            Destroy(gameObject);

            return;

        }

        //singleton soll nicht zerstört werden

        DontDestroyOnLoad(gameObject);

        foreach (Sound oneSound in sounds)

        {

            oneSound.audioSource = gameObject.AddComponent<AudioSource>();

            oneSound.audioSource.clip = oneSound.clip;

            oneSound.audioSource.volume = oneSound.volume;

            oneSound.audioSource.pitch = oneSound.pitch;

        }

    }

    void Play(string soundName)

    {

        FindSound(soundName).audioSource.Play();

    }

    void Pause(string soundName)

    {

        FindSound(soundName).audioSource.Pause();

    }


    private Sound FindSound(string soundName)

    {

        foreach (Sound oneSound in sounds)

        {

            if (oneSound.name == soundName)

            {

                return oneSound;

            }

        }

        return null;

    }


    // Start is called before the first frame update

    void Start()

    {

    }

    // Update is called once per frame

    void Update()

    {

    }

}
