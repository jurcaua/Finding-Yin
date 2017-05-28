using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOffsetMovement : MonoBehaviour {

    public float scrollSpeed = 5f;

    private MeshRenderer m;
    private float offset;
    
	void Start () {
        m = GetComponent<MeshRenderer>();
	}
	
	void Update () {
        m.material.mainTextureOffset = new Vector2(Time.time * scrollSpeed, 0f);
	}
}
