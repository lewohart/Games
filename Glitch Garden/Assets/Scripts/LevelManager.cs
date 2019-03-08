using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public float NextLevelTimeout;

    void Start () {
        if (NextLevelTimeout > 0) {
            Debug.Log (NextLevelTimeout);
            Invoke ("LoadNext", NextLevelTimeout);
        }
    }

    public void Load (string name) {
        SceneManager.LoadScene (name);
    }

    public void Quit () {
        Application.Quit ();
    }

    public void LoadNext () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }
}
