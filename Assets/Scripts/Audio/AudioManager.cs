using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager amInstance;

    public AudioSource music;
    public List<AudioClip> sfx;
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

    }
    public void UnMuteSFX()
    {

    }

}
