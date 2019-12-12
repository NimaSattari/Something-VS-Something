using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        AudioSource = GetComponent<AudioSource>();
        AudioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        AudioSource.volume = volume;
    }
}
