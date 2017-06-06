using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathSoundController : MonoBehaviour {

    public AudioSource firstBlood;
    public AudioSource nextDeaths;
    public static PlayerDeathSoundController instance = null;          
    int deathCounter = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        playPlayerDeathSound();
        playPlayerDeathSound();

        DontDestroyOnLoad(gameObject);
    }

    void playPlayerDeathSound()
    {
        deathCounter++;
        if (deathCounter == 1) firstBlood.Play();
        else nextDeaths.Play();
    }
}
