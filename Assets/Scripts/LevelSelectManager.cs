using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {

    public GameObject[] levelSelectBoxes;

    void Start() {
        List<Image> lanternIcons;
        List<bool> updatedlanternIcons;
        for (int i = 0; i < levelSelectBoxes.Length; i++) {

            if (GameController.instance.lanterns.ContainsKey(i)) {

                lanternIcons = new List<Image>();
                for (int j = 0; j < levelSelectBoxes[i].transform.childCount; j++) {
                    Image temp = levelSelectBoxes[i].transform.GetChild(j).GetComponent<Image>();
                    if (temp != null) {
                        lanternIcons.Add(temp);
                    }
                }

                updatedlanternIcons = GameController.instance.lanterns[i];
                for (int j = 0; j < updatedlanternIcons.Count; j++) {
                    Debug.Log(lanternIcons[j].name);
                    bool collected = updatedlanternIcons[j];
                    if (collected) {
                        lanternIcons[j].color = Color.white;

                    } else {
                        lanternIcons[j].color = Color.black;

                    }
                }
            }
        }
    }
}
