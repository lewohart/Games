using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
    public LevelManager LevelManager;
    public Slider VolumeSlider;
    public Slider DifficultySlider;

    private MusicManager musicManager;

    // Use this for initialization
    void Start () {
        this.musicManager = Object.FindObjectOfType<MusicManager> ();
        VolumeSlider.value = PlayerPrefsManager.MasterVolume;
        DifficultySlider.value = PlayerPrefsManager.Difficulty;
    }

    void Update () {
        musicManager.ChangeVolume (VolumeSlider.value);
    }

    public void SaveAndExit () {
        Debug.Log ("SaveAndExit");
        PlayerPrefsManager.MasterVolume = VolumeSlider.value;
        PlayerPrefsManager.Difficulty = DifficultySlider.value;
        LevelManager.Load ("01a - Start");
    }

    public void SetDefaults () {
        VolumeSlider.value = 0.8f;
        DifficultySlider.value = 2f;
    }
}
