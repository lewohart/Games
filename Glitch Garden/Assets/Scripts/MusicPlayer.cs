using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer instance = null;

    void Awake () {
        if (instance == null) {
            instance = this;
            GameObject.DontDestroyOnLoad (gameObject);
        }
        else {
            Destroy (gameObject);
        }
    }
}
