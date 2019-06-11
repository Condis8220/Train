using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Signal : MonoBehaviour
{
    public AudioClip signalClip;
    private AudioSource audioSource;

    public Button buttonSignal;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        buttonSignal.onClick.AddListener(ButtonSignal);
    }

    private void ButtonSignal()
    {
        if (audioSource.isPlaying)
            return;

        audioSource.clip = signalClip;
        audioSource.Play();
    }
}
