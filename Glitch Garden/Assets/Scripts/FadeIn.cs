using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float Interval;

    private Image fadePanel;
    private Color currentColor;

    void Start () {
        this.fadePanel = GetComponent<Image> ();
        this.currentColor = this.fadePanel.color;
    }

    // Update is called once per frame
    void Update () {
        if (Time.timeSinceLevelLoad < Interval) {
            float alpha = Time.deltaTime / Interval;
            currentColor.a -= alpha;
            this.fadePanel.color = currentColor;
        }
        else {
            gameObject.SetActive (false);
        }
    }
}
