using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour {

    public int levelNumber = 1;

	public void ChangeLevel() {
        SceneManager.LoadScene("level_" + levelNumber.ToString());
    }
}
