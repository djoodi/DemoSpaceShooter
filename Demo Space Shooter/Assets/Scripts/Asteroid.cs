using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float moveSpeed;

    public float moveMin;
    public float moveMax;
    public float horizontalDrift;

    public Sprite[] sprites = new Sprite[4];

    private SpriteRenderer mySR;
    private Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        mySR = GetComponent<SpriteRenderer>();

        float horizontal = Random.Range(moveMin, moveMax) * Random.Range(-horizontalDrift, horizontalDrift);
        float vertical = Random.Range(moveMin, moveMax) * -1;

        Vector2 movement = new Vector2(horizontal, vertical);
        myRB.velocity = movement;

        int index = Mathf.FloorToInt(Random.Range(0, 4));
        mySR.sprite = sprites[index];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.instance.AddScore();
        }
    }
}
