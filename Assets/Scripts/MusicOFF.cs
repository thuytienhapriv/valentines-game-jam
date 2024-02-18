using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOFF : MonoBehaviour
{
    AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        if (music == null)
            music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopThisShit()
    {
        if (music.isPlaying)
            music.Stop();
    }
}
