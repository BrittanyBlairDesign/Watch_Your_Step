using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEffects : MonoBehaviour
{

    //Sounds

    [SerializeField] private AudioSource Gem1;
    [SerializeField] private AudioSource Gem2;
    [SerializeField] private AudioSource Gem3;

    public void PlayGem1()
    {
        Gem1.Play();
    }
    public void PlayGem2()
    {
        Gem2.Play();
    }
    public void PlayGem3()
    {
        Gem3.Play();
    }
}
