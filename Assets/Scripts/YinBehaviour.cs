using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YinBehaviour : MonoBehaviour {

    public GameController gameController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Yang") {
            gameController.LevelComplete();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Yang") {
            gameController.LevelMeh();
        }
    }
}
