using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float projectileLifetime = 1f;
    private float currentLerpTime = 0f;

    private Vector3 startScale;

    [HideInInspector] public PlayerController player;
    private SpriteRenderer eye;

    void Start () {
        Destroy(gameObject, projectileLifetime); // destroy this object after set lifetime

        startScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z); // keep track of current scale

        eye = player.eye;
        //player = GameObject.FindGameObjectWithTag("Yang").GetComponent<PlayerController>(); // find the player so we can alert when he can shoot again
    }

    void Update() {
        transform.localScale = Vector3.Lerp(startScale, Vector3.zero, currentLerpTime / projectileLifetime);

        currentLerpTime += Time.deltaTime;
    }

    void OnDestroy() {
        player.canShoot = true;
        eye.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer != gameObject.layer) {
            Destroy(gameObject);
        }
    }
}
