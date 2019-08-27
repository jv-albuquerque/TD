using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeChange : MonoBehaviour
{
    [Header("Music Properties")]
    [SerializeField] AudioSource[] MusicAudioSrcs = null;
    [SerializeField] Slider MusicSlider = null;

    [Header("Effects Properties")]
    [SerializeField] AudioSource[] EffectAudioSrcs = null;
    [SerializeField] Slider EffectSlider = null;

    // Start is called before the first frame update
    void Start()
    {
        //get the store values of the sounds volume
        // ---
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.7f); 

        EffectSlider.value = PlayerPrefs.GetFloat("EffectVolume", 0.7f);
        // ---

        UpdateVolume();
    }

    //Used to the Handler set the music volume
    public void SetMusicVolume(float vol)
    {
        PlayerPrefs.SetFloat("MusicVolume", vol);

        for (int i = 0; i < MusicAudioSrcs.Length; i++)
        {
            MusicAudioSrcs[i].volume = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
        }
    }

    //Used to the Handler set the effect volume
    public void SetEffectVolume(float vol)
    {
        PlayerPrefs.SetFloat("EffectVolume", vol);

        for (int i = 0; i < EffectAudioSrcs.Length; i++)
        {
            EffectAudioSrcs[i].volume = PlayerPrefs.GetFloat("EffectVolume", 0.7f);
        }
    }

    //Update all the sounds in the game, music and effects
    private void UpdateVolume()
    {
        for (int i = 0; i < MusicAudioSrcs.Length; i++)
        {
            MusicAudioSrcs[i].volume = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
        }

        for (int i = 0; i < EffectAudioSrcs.Length; i++)
        {
            EffectAudioSrcs[i].volume = PlayerPrefs.GetFloat("EffectVolume", 0.7f);
        }
    }
}
