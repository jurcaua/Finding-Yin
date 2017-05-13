using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float jumpForce = 5f;

    private bool grounded = true;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public Transform projectileSpawn;
    public GameObject projectile;
    public float projectileSpeed = 10f;

    private Rigidbody2D r;
    private Vector2 velocity;
    private int facingRight = 1;

    private SpriteRenderer s;

	void Start () {
        r = GetComponent<Rigidbody2D>();
        s = GetComponent <SpriteRenderer> ();
	}
	
	void Update () {
        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))) {
            r.AddForce(new Vector2(0f, jumpForce));
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject bullet = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation) as GameObject;

            Rigidbody2D bulletR = bullet.GetComponent<Rigidbody2D>();
            if (bulletR == null) {
                Debug.Log("No Rigidbody2D on bullet! Problem!!!");
                return;
            }

            bulletR.velocity = new Vector2(facingRight * projectileSpeed, 0f);
        }
	}

    void FixedUpdate() {
        r.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, r.velocity.y);

        if (r.velocity.x != 0f) {
            facingRight = (int)Mathf.Sign(r.velocity.x);
            s.flipX = (facingRight == 1) ? false: true ;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }
}
