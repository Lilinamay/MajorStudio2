using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// manage audios 
public class Audiomanager : MonoBehaviour
{
    public static Audiomanager Instance;
    public GameObject SoundPrefab;
    //play following sound in the sound prefab
    public AudioClip becomeStrong;
    [Range(0f, 1f)] public float strongVolume = 1.0f;
    public AudioClip boyEmote;   //snowball hit surfaces
    [Range(0f, 1f)] public float emoteVolume = 1.0f;
    [Space(10)]

    public AudioClip boyHurt;  //when player enter arch
    [Range(0f, 1f)] public float boyHurtVolume = 1.0f;
    public AudioClip punch;
    [Range(0f, 1f)] public float punchVolume = 1.0f;
    public AudioClip girlHurt;  //during dialogue
    [Range(0f, 1f)] public float girlHurtVolume = 1.0f;
    public AudioClip win;  //during dialogue
    [Range(0f, 1f)] public float winVolume = 1.0f;
    public AudioClip lose;  //during dialogue
    [Range(0f, 1f)] public float loseVolume = 1.0f;
    public AudioClip kiss;  //during dialogue
    [Range(0f, 1f)] public float kissVolume = 1.0f;



    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        if (Instance == null)       //make sure it functions
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(AudioClip clipToPlay, float volume = 0.5f)        //public function to play sound when needed
    {
        if (clipToPlay == null)         //if nothing to play
        {
            //Debug.Log("AUDIO CLIP NOT ASSIGNED ON AUDIO DIRECTOR!");
            return;
        }

        GameObject newSound = Instantiate(SoundPrefab, Vector3.zero, Quaternion.identity);  //create audiosource to play sound
        AudioSource newSoundSource = newSound.GetComponent<AudioSource>();
        newSoundSource.clip = clipToPlay;
        newSoundSource.volume = volume;
        //Debug.Log("volume" + volume);
        newSoundSource.Play();
        Destroy(newSound, clipToPlay.length);   //finish play sound delete
    }
}

//Audiomanager.Instance.PlaySound(Audiomanager.Instance.CheckSound, Audiomanager.Instance.CheckVolume);

