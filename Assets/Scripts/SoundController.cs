using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    // 定义音频剪辑
    public AudioClip GetGrain;
    public AudioClip GrowSeed;
    public AudioClip click;
    public AudioClip button;
    public AudioClip moneyChange;
    public AudioClip workOneWorking;
    public AudioClip envelop;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // 播放音效1
    public void GETGRAIN()
    {
        audioSource.clip = GetGrain;
        audioSource.Play();
    }
    public void GrowSEED()
    {
        audioSource.clip = GrowSeed;
        audioSource.Play();
    }
    public void CLICK()
    {
        audioSource.clip = click;
        audioSource.Play();
    }
    public void BUTTON()
    {
        audioSource.clip = button;
        audioSource.Play();
    }
    public void MONEYCHANGE()
    {
        audioSource.clip = moneyChange;
        audioSource.Play();
    }
    public void WORKINGONEWORKING()
    {
        audioSource.clip = workOneWorking;
        audioSource.Play();
    }
    public void ENVELOP()
    {
        audioSource.clip = envelop;
        audioSource.Play();
    }
    public void StopWorkingSound()
    {
        audioSource.Stop();
    }
}
