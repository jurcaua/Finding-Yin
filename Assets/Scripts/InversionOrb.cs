using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class InversionOrb : MonoBehaviour {

    public float inversionLength = 3f;

    [Header("Post Processing")]
    public PostProcessingBehaviour postProcessingScript;
    public PostProcessingProfile standard;
    public PostProcessingProfile blackAndWhite;

    private PlayerController yinPlayerController;

    private void Start() {
        yinPlayerController = GameObject.FindGameObjectWithTag("Yin").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Yang") {
            StartCoroutine(InversionMode());
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
        yield return new WaitForSeconds(inversionLength);

        // end of timer play snap sound effect

        // revert profile to standard
        postProcessingScript.profile = standard;

        // disable control for yin
        yinPlayerController.enabled = false;
    }
}
