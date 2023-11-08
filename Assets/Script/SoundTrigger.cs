using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public bool isMusic;
    public float repCD;
    float currentCD;
    public GameObject obj;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isMusic) { currentCD = repCD; audioSource.Pause(); }
        else { audioSource.Play(); }
        Debug.Log("Did things.");
    }

    private void OnTriggerStay(Collider other)
    {
        if (isMusic && currentCD <= 0)
        {
            audioSource.Play();
            currentCD = repCD;
            Debug.Log("played sound");
        }
        currentCD -= Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        if (isMusic)
        {
            audioSource.UnPause();
            Debug.Log("Attempted to unpause.");
        }
    }
}
