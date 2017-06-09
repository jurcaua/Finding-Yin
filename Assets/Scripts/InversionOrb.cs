using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PostProcessing;

public class InversionOrb : MonoBehaviour {

    public float inversionLength = 3f;
    private int mSecondsLeft;

    [Header("Post Processing")]
    public PostProcessingBehaviour postProcessingScript;
    public PostProcessingProfile standard;
    public PostProcessingProfile blackAndWhite;

    private PlayerController yinPlayerController;

    public GameObject timer;
    private Slider timerSlider;
    private TextMeshProUGUI timerText;

    private bool go = false;

    private void Start() {
        yinPlayerController = GameObject.FindGameObjectWithTag("Yin").GetComponent<PlayerController>();
        
        timerSlider = timer.GetComponent<Slider>();
        timerText = timer.GetComponentInChildren<TextMeshProUGUI>();

        mSecondsLeft = Mathf.RoundToInt(inversionLength * 1000f);
        timerSlider.minValue = 0f;
        timerSlider.maxValue = mSecondsLeft;
        timerSlider.value = mSecondsLeft;
        timerText.text = ((mSecondsLeft / 1000) % 10).ToString() + ":" + ((mSecondsLeft / 100) % 10).ToString() + ((mSecondsLeft / 10) % 10).ToString() + "\"";
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Yang") {
            StartCoroutine(InversionMode());
        }
    }

    void Update() {
        if (go) {
            mSecondsLeft -= Mathf.RoundToInt(Time.deltaTime * 1000);
            if (mSecondsLeft < 0) {
                mSecondsLeft = 0;
                go = false;
            }

            timerSlider.value = mSecondsLeft;
            timerText.text = ((mSecondsLeft / 1000) % 10).ToString() + ":" + ((mSecondsLeft / 100) % 10).ToString() + ((mSecondsLeft / 10) % 10).ToString() + "\"";
        }
    }

    IEnumerator InversionMode() {
        // stop showing this object
        GameObject child = transform.GetChild(0).gameObject;
        child.SetActive(false);

        // play inversion sound effect

        // go black and white
        postProcessingScript.profile = blackAndWhite;

        // enable control for yin
        yinPlayerController.enabled = true;

        // start timer sound

        // start timer
        timer.SetActive(true);
        go = true;
        yield return new WaitForSeconds(inversionLength);

        // end of timer play snap sound effect
        go = false;
        timer.SetActive(false);

        // revert profile to standard
        postProcessingScript.profile = standard;

        // disable control for yin
        yinPlayerController.enabled = false;

        Destroy(gameObject);
    }
}
