using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour {

    public int levelNumber;

	public void ChangeLevel() {
        GameController.instance.currentLevel = levelNumber;

        SceneManager.LoadScene("level_" + levelNumber.ToString());
    }
}
