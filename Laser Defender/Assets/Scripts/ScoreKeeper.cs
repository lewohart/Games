using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScoreKeeper: MonoBehaviour {

    public static int Points { get; set; }
    private Text ScoreText;

    void Start() {
        this.ScoreText = GetComponent<Text>();
        ScoreText.text = Convert.ToString(0);
    }

    public void Score(int points) {
        Points += points;
        this.ScoreText.text = Convert.ToString(Points);
    }

    public static void Reset() {
        Points = 0;
    }
}
