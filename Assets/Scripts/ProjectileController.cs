﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float projectileLifetime = 1f;
    private float currentLerpTime = 0f;

    private Vector3 startScale;

    private PlayerController player;

    void Start () {
        Destroy(gameObject, projectileLifetime);

        startScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update() {
        transform.localScale = Vector3.Lerp(startScale, Vector3.zero, currentLerpTime / projectileLifetime);

        currentLerpTime += Time.deltaTime;
    }

    void OnDestroy() {
        player.canShoot = true;
    }
}
