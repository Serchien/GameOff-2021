using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBoxManager : MonoBehaviour
{
    AudioSource audio;
    [SerializeField] AudioClip[] clips;
    int index = 0;

    static bool isTheOne = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        if (isTheOne)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            isTheOne = true;
            PlaySong();

        }


    }

    void PlaySong()
    {
        if (index > clips.Length - 1) index = 0;
        audio.clip = clips[index];
        audio.Play();
        index++;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            PlaySong();
        }
    }

}
