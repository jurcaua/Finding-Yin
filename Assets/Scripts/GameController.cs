using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour {

    public static GameController instance = null;

    public Dictionary<int, List<bool>> lanterns = new Dictionary<int, List<bool>>();
    public int currentLevel;

	void Awake () {
        if (instance == null) {
            instance = this;
        } else if (instance != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        
    }

    public void UpdateLanternSet(bool[] lanternsFound) {
        if (lanterns.ContainsKey(currentLevel - 1)) {
            Debug.Log("This level has been completed before!");
            for (int i = 0; i < lanternsFound.Length; i++) {
                if (lanterns[currentLevel - 1][i]) {
                    lanternsFound[i] = true;
                }
            }
            lanterns[currentLevel - 1] = new List<bool>(lanternsFound);
        } else {
            Debug.Log("First time the level has been completed!");
            lanterns.Add(currentLevel - 1, new List<bool>(lanternsFound));
        }

        Debug.Log("Level Index:" + currentLevel + " with lanterns: " + lanternsFound[0].ToString() + lanternsFound[1].ToString() + lanternsFound[2].ToString());
    }
}
