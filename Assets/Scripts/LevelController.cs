using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public bool levelComplete = false;
    public bool[] lanternsFound;
    private int numLanterns;

    private PlayerController playerController;
    private PlayerController playerControllerYin;
    private CameraController cameraController;
    private Fader fader;

    void Start() {
        numLanterns = GameObject.FindGameObjectsWithTag("Lantern").Length;

        lanternsFound = new bool[numLanterns];
        for (int i = 0; i < lanternsFound.Length; i++) {
            lanternsFound[i] = false;
        }

        playerController = GameObject.FindGameObjectWithTag("Yang").GetComponent<PlayerController>();
        playerControllerYin = GameObject.FindGameObjectWithTag("Yin").GetComponent<PlayerController>();
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

    public void RestartLevel() {
        fader.FadeOut();

        Invoke("ReloadCurrentLevel", fader.fadeTime + 1f);
    }

    public void LevelComplete() {
        fader.FadeOut();
        levelComplete = true;
        playerController.enabled = false; // disable movement for player
        playerControllerYin.enabled = false; // disable movement for yin

        GameController.instance.UpdateLanternSet(lanternsFound);

        Invoke("ReturnToLevelSelection", fader.fadeTime + 1f);
    }

    void ReturnToLevelSelection() {
        SceneManager.LoadScene("level_selection");
    }

    void ReloadCurrentLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LanternCollected(int lanternIndex) {
        lanternsFound[lanternIndex] = true;
    }

}
