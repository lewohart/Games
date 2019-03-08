using System;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplay : MonoBehaviour {
	// Use this for initialization
	void Start () {
        var display = GetComponent<Text>();
        display.text = Convert.ToString(ScoreKeeper.Points);   	
	}
}
