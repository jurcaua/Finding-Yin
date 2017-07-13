using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LanternController : MonoBehaviour {

    public int lanternIndex;
    public GameObject collectParticleEffect;

    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;
    private LevelController levelController;

	void Start () {
        levelController = GameObject.FindGameObjectWithTag("Yin").GetComponent<LevelController>();
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Yang" || collision.gameObject.tag == "Yin") {
            // the z value needs to be zero but the rest is the position of the lantern
            Vector3 particlePosition = new Vector3(transform.position.x, transform.position.y, -6f);

            // create the particle effect
            GameObject particleEffect = Instantiate(collectParticleEffect, particlePosition, Quaternion.Euler(-90f, 0f, 0f)) as GameObject;
            
            // find out the length of it, and destroy it after it is done
            float particleLength = particleEffect.GetComponent<ParticleSystem>().main.startLifetime.constant;
            Destroy(particleEffect, particleLength);

            // tell the LevelController that this lantern has been collected
            levelController.LanternCollected(lanternIndex);

            // disable visbility and trigge collisons for the object but we have to destroy it after the particle effect is done
            spriteRenderer.enabled = false;
            circleCollider.enabled = false;
            Destroy(gameObject, particleLength + 1f);
        }
    }
}
