using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour {

    public TextMeshProUGUI text;

    private PlayerController playerController;
    private bool levelComplete = false;

	void Awake () {
        playerController = GameObject.FindGameObjectWithTag("Yang").GetComponent<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {
		
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
