using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour {

    public static GameController instance = null;

    //public TextMeshProUGUI text;

    private PlayerController playerController;
    private CameraController cameraController;

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
}
