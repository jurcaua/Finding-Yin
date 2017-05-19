using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LightUpPlatform : MonoBehaviour {

    public float transitionTime = 0.2f;

    private SpriteRenderer s;

    private Color fromColor;
    private Color toColor;
    private bool go = false;

    private float currentLerpTime = 0f;

    // Use this for initialization
    void Start() {
        s = GetComponent<SpriteRenderer>();

        fromColor = s.color;
        toColor = new Color(1, 1, 1, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        currentLerpTime = 0f;
        go = true;
        fromColor = s.color;
        toColor = new Color(1, 1f, 1f, 1f);
    }

    void OnCollisionExit2D(Collision2D collision) {
        currentLerpTime = 0f;
        go = true;
        fromColor = s.color;
        toColor = new Color(1f, 1f, 1f, 0f);
    }

    void Update() {
        if (go) {
            s.color = Color.Lerp(fromColor, toColor, currentLerpTime/transitionTime);

            if (currentLerpTime > transitionTime) {
                go = false;
            } else {
                currentLerpTime += Time.deltaTime;
            }
        }
    }
}
