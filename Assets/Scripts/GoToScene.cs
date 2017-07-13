using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {
    
    public void GoToLevelSelection() {
        SceneManager.LoadScene("level_selection");
    }

    public void GoToSettings() {
        SceneManager.LoadScene("settings");
    }

    public void GoToStartMenu() {
        SceneManager.LoadScene("start_menu");
    }

    public void RestartCurrentScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
