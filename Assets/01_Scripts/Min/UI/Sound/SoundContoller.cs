using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundContoller : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider MasterAudioSlider;
    public Slider BGMAudioSlider;
    public Slider FXAudioSlider;

    float Mastersound;
    float BGMsound;
    float FXsound;

    private void Start()
    {
        MasterAudioSlider.value = PlayerPrefs.GetFloat("Master");
        BGMAudioSlider.value = PlayerPrefs.GetFloat("BGM");
        FXAudioSlider.value = PlayerPrefs.GetFloat("FX");
        Mastersound = MasterAudioSlider.value;
        BGMsound = BGMAudioSlider.value;
        FXsound = FXAudioSlider.value;
    }

    public void MasterAudioControl()
    {
        Mastersound = MasterAudioSlider.value;

        if (Mastersound == -40f)
        {
            masterMixer.SetFloat("Master", -80);
        }
        else
        {
            masterMixer.SetFloat("Master", Mastersound);
        }
        PlayerPrefs.SetFloat("Master", MasterAudioSlider.value);

    }

    public void BGMAudioControl()
    {
        BGMsound = BGMAudioSlider.value;

        if (BGMsound == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", BGMsound);
        }
        PlayerPrefs.SetFloat("BGM", BGMAudioSlider.value);

    }

    public void FXAudioControl()
    {
        FXsound = FXAudioSlider.value;
        if (FXsound == -40f)
        {
            masterMixer.SetFloat("FX", -80);
        }
        else
        {
            masterMixer.SetFloat("FX", FXsound);
        }

        PlayerPrefs.SetFloat("FX", FXAudioSlider.value);

    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
