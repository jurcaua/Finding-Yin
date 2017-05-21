using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Fader : MonoBehaviour {

    private Image image;

    public float fadeTime = 2f;

    private float currentLerpTime = 1.1f;
    private Color fromColor;
    private Color toColor;
    
    void Start () {
        image = GetComponent<Image>();
        image.color = Color.black;
	}

    void Update() {
        if (currentLerpTime <= fadeTime) {
            image.color = Color.Lerp(fromColor, toColor, currentLerpTime / fadeTime);
            currentLerpTime += Time.deltaTime;
        }
    }

    public void FadeIn() {
        currentLerpTime = 0f;
        fromColor = image.color;
        toColor = new Color(0f, 0f, 0f, 0f);
    }

    public void FadeOut() {
        currentLerpTime = 0f;
        fromColor = image.color;
        toColor = new Color(0f, 0f, 0f, 1f);
    }
}
