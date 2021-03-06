﻿using UnityEngine;

public class MusicPlayer: MonoBehaviour {
    static MusicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

    void Start() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
            print("Duplicate music player self-destructing!");
        }
        else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            OnLevelWasLoaded(0);
        }
    }

    void OnLevelWasLoaded(int level) {
        Debug.Log("MusicPlayer: loaded level " + level);
        music.Stop();

        switch (level) {
        case 0:
            music.clip = startClip;
            break;
        case 1:
            music.clip = gameClip;
            break;
        case 2:
            music.clip = endClip;
            break;
        }

        music.loop = true;
        music.Play();
    }
}
