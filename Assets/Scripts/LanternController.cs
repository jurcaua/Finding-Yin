using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour {

    public int lanternIndex;

    private LevelController levelController;

	void Start () {
        levelController = GameObject.FindGameObjectWithTag("Yin").GetComponent<LevelController>();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Yang") {
            Destroy(gameObject);

            levelController.LanternCollected(lanternIndex);
        }
    }
}
