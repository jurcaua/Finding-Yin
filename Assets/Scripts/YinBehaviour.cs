using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YinBehaviour : MonoBehaviour {

    private LevelController levelController;

	// Use this for initialization
	void Start () {
        levelController = GameObject.FindGameObjectWithTag("Yin").GetComponent<LevelController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Yang") {
            levelController.LevelComplete();
        }
    }
}
