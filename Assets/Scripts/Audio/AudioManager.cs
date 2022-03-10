using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager amInstance;

    public AudioSource music;
    public AudioSource SFX;
    public List<AudioClip> sfxList;
    private void Awake()
    {
        if(amInstance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        amInstance = this;
        DontDestroyOnLoad(this);
    }
    
    public void MuteMusic()
    {
        music.volume = 0;
    }
    public void UnMuteMusic()
    {
        music.volume = 1;
    }
    public void MuteSFX()
    {
        SFX.volume = 0;
    }
    public void UnMuteSFX()
    {
        SFX.volume = 1;
    }

}
