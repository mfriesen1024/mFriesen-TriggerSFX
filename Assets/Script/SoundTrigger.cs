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
    float t;
    // Start is called before the first frame update
    void Start()
    {

        audioSource = obj.GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isMusic) { currentCD = repCD; audioSource.Pause(); t = audioSource.time; }
        else { audioSource.Play(); currentCD = repCD; }
        Debug.Log("Did things.");
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentCD <= 0 && !isMusic)
        {
            Debug.Log(currentCD);
            audioSource.Play();
            currentCD = repCD;
            Debug.Log(currentCD);
            Debug.Log("played sound");
        }
        currentCD -= Time.deltaTime;
        Debug.Log(currentCD);
    }

    private void OnTriggerExit(Collider other)
    {
        if (isMusic)
        {
            audioSource.Play();
            // I don't remember if we were supposed to do this, but because unity decided to break, I forced it to work anyway using the line below.
            audioSource.time = t;
            Debug.Log("Attempted to unpause.");
        }
    }
}
