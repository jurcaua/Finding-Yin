using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxes : MonoBehaviour {

    private LevelController levelController;

    void Start() {
        levelController = GameObject.FindGameObjectWithTag("Yin").GetComponent<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Yang" || collision.gameObject.tag == "Yin") {
            levelController.RestartLevel();
        }
    }
}
