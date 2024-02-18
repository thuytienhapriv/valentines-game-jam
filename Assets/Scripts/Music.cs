using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        if (musicSource == null)
            musicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        musicSource.Play();
    }

    public void Stop() {
        musicSource.Stop();
    }


}
