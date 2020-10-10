using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    public float fireRate;
    public float shootOffset;
    public GameObject bulletPrefab;

    private Rigidbody2D myRB;
    private Animator myAnim;

    private float shootInterval;
    private float shootTimer;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        shootInterval = 1 / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        myAnim.SetFloat("turn", Mathf.Abs(horizontal));

        Vector2 movement = new Vector2(horizontal, vertical).normalized;

        myRB.velocity = movement * moveSpeed;

        if (Input.GetButton("Fire1") && shootTimer > shootInterval)
        {
            Vector3 bulletSpawn = new Vector3(transform.position.x, transform.position.y + shootOffset, 0);

            Instantiate(bulletPrefab, bulletSpawn, bulletPrefab.transform.rotation);

            shootTimer = 0;
        }

        shootTimer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameManager.instance.KillPlayer();
        }
    }
}
