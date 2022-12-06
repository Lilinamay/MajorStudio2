using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// manage audios 
public class Audiomanager : MonoBehaviour
{
    public static Audiomanager Instance;
    public GameObject SoundPrefab;
    //play following sound in the sound prefab
    public AudioClip shoot;
    [Range(0f, 1f)] public float shootVolume = 1.0f;
    public AudioClip hit;   //snowball hit surfaces
    [Range(0f, 1f)] public float hitVolume = 1.0f;
    [Space(10)]

    public AudioClip arch;  //when player enter arch
    [Range(0f, 1f)] public float archVolume = 1.0f;
    public AudioClip dash;
    [Range(0f, 1f)] public float dashVolume = 1.0f;
    public AudioClip jump;
    [Range(0f, 1f)] public float jumpVolume = 1.0f;
    public AudioClip text;  //during dialogue
    [Range(0f, 1f)] public float textVolume = 1.0f;
    public AudioClip getsnow;
    [Range(0f, 1f)] public float getsnowVolume = 1.0f;
    public AudioClip horse;
    [Range(0f, 1f)] public float horseVolume = 1.0f;


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

