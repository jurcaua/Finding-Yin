using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public bool levelComplete = false;

    private PlayerController playerController;
    private CameraController cameraController;
    private Fader fader;

    void Start() {
        playerController = GameObject.FindGameObjectWithTag("Yang").GetComponent<PlayerController>();
        cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<Fader>();

        fader.FadeIn();
    }

    // Update is called once per frame
    void Update() {
        if (levelComplete) {
            cameraController.LevelOverMovement(); // disables things to allow for final zoom in
            cameraController.Zoom(); // zoom on targets
        }
    }

    public void LevelComplete() {
        fader.FadeOut();
        levelComplete = true;
        playerController.enabled = false; // disable movement for player
        Invoke("ReturnToLevelSelection", fader.fadeTime + 1f);
    }

    void ReturnToLevelSelection() {
        SceneManager.LoadScene("level_selection");
    }

}
