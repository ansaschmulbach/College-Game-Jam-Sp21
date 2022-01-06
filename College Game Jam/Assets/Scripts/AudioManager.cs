using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] public Sound mainSound;
    private AudioListener audioListener;
    private static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        audioListener = FindObjectOfType<AudioListener>(); 
        AudioSource source =  gameObject.AddComponent<AudioSource>();
        source.clip = mainSound.clip;
        source.volume = mainSound.volume;
        source.loop = true;
        mainSound.source = source;
    }
    
    void Start()
    {
        mainSound.source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        mainSound.source.volume = mainSound.volume;
    }
}
