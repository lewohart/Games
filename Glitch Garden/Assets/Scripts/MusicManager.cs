using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] LevelMusics;
    private AudioSource audioSource;

    void Start () {
        this.audioSource = GetComponent<AudioSource> ();
        this.audioSource.volume = PlayerPrefsManager.MasterVolume;
    }

    void Awake () {
        Debug.Log ("Don't destroy on load: " + name);
        DontDestroyOnLoad (gameObject);
    }

    void OnLevelWasLoaded (int level) {
        Debug.Log ("Playing clip: " + level + " of " + LevelMusics.Length);
        var levelClip = LevelMusics[level];

        if (levelClip != null) {
            audioSource.clip = levelClip;
            audioSource.loop = true;
            audioSource.Play ();
        }
    }

    public void ChangeVolume (float volume) {
        audioSource.volume = volume;
    }
}
