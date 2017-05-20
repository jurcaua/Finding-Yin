using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour {

    public static GameController instance = null;

    public TextMeshProUGUI text;

    private PlayerController playerController;
    private CameraController cameraController;
    private bool levelComplete = false;

	void Awake () {
        if (instance == null) {
            instance = this;
        } else if (instance != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        playerController = GameObject.FindGameObjectWithTag("Yang").GetComponent<PlayerController>();
        cameraController = GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update () {
		if (levelComplete) {
            cameraController.LevelOverMovement(); // disables things to allow for final zoom in
            cameraController.Zoom(); // zoom on targets
            playerController.enabled = false; // disable movement for player
        }
	}

    public void LevelComplete() {
        levelComplete = true;
        text.text = "Level Complete!";
    }

    public void LevelMeh() {
        levelComplete = false;
        text.text = "Oops";
    }
}
