using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {
    public static float MasterVolume {
        get {
            float volume = PlayerPrefs.GetFloat ("MasterVolume");
            Debug.Log (string.Format ("MasterVolume: {0} ", volume));
            return volume;
        }
        set {
            PlayerPrefs.SetFloat ("MasterVolume", Mathf.Clamp (value, 0f, 1f));
            Debug.Log (string.Format ("MasterVolume: {0} ", PlayerPrefs.GetFloat ("MasterVolume")));
        }
    }

    public static float Difficulty {
        get {
            float dificulty = PlayerPrefs.GetFloat ("Dificulty");
            Debug.Log (string.Format ("Dificulty: {0} ", dificulty));
            return dificulty;
        }
        set {
            PlayerPrefs.SetFloat ("Dificulty", Mathf.Clamp (value, 1f, 3f));
            Debug.Log (string.Format ("Dificulty: {0} ", PlayerPrefs.GetFloat ("Dificulty")));
        }
    }

    public static void UnlockLevel (int level) {
        var key = string.Format ("LevelUnlocked{0}", level);

        if (0 <= level && level < SceneManager.sceneCountInBuildSettings - 1)
            PlayerPrefs.SetInt (key, 1);

        Debug.Log (string.Format ("{0}: {1} ", key, PlayerPrefs.GetFloat (key)));

    }

    public bool IsLevelUnlock (int level) {
        var key = string.Format ("LevelUnlocked{0}", level);
        Debug.Log (string.Format ("{0}: {1} ", key, PlayerPrefs.GetFloat (key)));

        return (0 <= level && level < SceneManager.sceneCountInBuildSettings - 1) &&
            PlayerPrefs.GetInt (key) == 1;
    }
}
