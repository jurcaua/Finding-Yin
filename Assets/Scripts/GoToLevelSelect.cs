using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevelSelect : MonoBehaviour {
    
    public void GoToLevelSelection() {
        SceneManager.LoadScene("level_selection");
    }

    public void GoToSettings() {
        SceneManager.LoadScene("settings");
    }

    public void GoToStartMenu() {
        SceneManager.LoadScene("start_menu");
    }
}
