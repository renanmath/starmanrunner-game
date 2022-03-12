using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager instance;
    public AudioClip shootSound;
    public AudioClip catchHeartSound;
    public AudioClip catchAmmutionSound;
    public AudioClip hitEnemySound;
    public AudioClip destroyEnemySound;

    public bool effectsOn;
    public bool bgmOn;

    private AudioSource audioSource;

    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        effectsOn = true;
        bgmOn = true;
        
    }

  public void playSound(AudioClip audio)
  {
      if(effectsOn)
      {
          audioSource.PlayOneShot(audio);
      }
  }


    public void changeAudioStatus(float status)
    {   
        if(status == 1f)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
        
    }

}
