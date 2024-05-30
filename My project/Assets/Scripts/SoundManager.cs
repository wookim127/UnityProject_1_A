using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]

public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1.0f;
    [Range(0.1f, 3f)]
    public float pitch = 1.0f;
    public bool loop;
    public AudioMixerGroup mixerGroup;

    [HideInInspector]
    public AudioSource sources;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public List<Sound> sounds = new List<Sound>();        //사운드 리스트 관리
    public AudioMixer audioMixer;        //오디오 믹서 참조
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }



        foreach (Sound sound in sounds)
        {
            sound.sources = gameObject.AddComponent<AudioSource>();
            sound.sources.clip = sound.clip;
            sound.sources.volume = sound.pitch;
            sound.sources.loop = sound.loop;
            sound.sources.outputAudioMixerGroup = sound.mixerGroup;
        }

    }


        public void PlaySound(string name)
        {
            Sound soundToPlay = sounds.Find(sound => sound.name == name);

            if (soundToPlay != null)
            {
                soundToPlay.sources.Play();
            }
            else
            {
                Debug.LogWarning("사운드 " + name + " 찾을 수 없다.");
            }
        }
        
    }                      

