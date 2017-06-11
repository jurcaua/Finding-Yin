using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float jumpForce = 5f;

    private bool grounded = true;
    public Transform[] groundChecks;
    private float groundRadius = 0.5f;
    public LayerMask whatIsGround;

    public SpriteRenderer eye;
    public Transform projectileSpawn;
    public GameObject projectile;
    public float projectileSpeed = 10f;
    public float shotDelay = 0.1f;
    public bool canShoot = true;

    private Rigidbody2D r;
    private Vector2 velocity;
    public int facingRight = 1;

    void Start () {
        r = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))) {
            r.AddForce(new Vector2(0f, jumpForce));
        }

        if (canShoot) { // they can shoot
            if (Input.GetKeyDown(KeyCode.Space)) { // they can shoot and have shot
                StartCoroutine(Shoot(shotDelay));
            } else { // they can shoot but arent
                eye.enabled = true;
            }
        }
	}

    void FixedUpdate() {
        r.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, r.velocity.y);

        if (r.velocity.x != 0f) {
            facingRight = (int)Mathf.Sign(r.velocity.x);
            transform.localScale = new Vector3((facingRight == 1) ? 1 : -1, transform.localScale.y, transform.localScale.z);

            if (gameObject.tag == "Yin") {
                facingRight *= -1;
            }
        }

        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        grounded = IsGrounded();
    }

    IEnumerator Shoot(float delay) {
        canShoot = false;

        yield return new WaitForSeconds(delay);

        eye.enabled = false;

        GameObject bullet = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation) as GameObject;
        bullet.GetComponent<ProjectileController>().player = this;

        Rigidbody2D bulletR = bullet.GetComponent<Rigidbody2D>();
        if (bulletR == null) {
            Debug.Log("No Rigidbody2D on bullet! Problem!!!");
        } else {
            bulletR.velocity = new Vector2(facingRight * projectileSpeed, 0f);
        }
    }

    bool IsGrounded() {
        for (int i = 0; i < groundChecks.Length; i++) {
            if (Physics2D.OverlapCircle(groundChecks[i].position, groundRadius, whatIsGround) == true) {
                return true;
            }
        }
        return false;
    }
}
