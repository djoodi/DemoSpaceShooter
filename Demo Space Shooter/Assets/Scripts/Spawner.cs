using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate;

    private float spawnTimer;

    private Collider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float interval = 1 / spawnRate;

        spawnTimer += Time.deltaTime;

        if (spawnTimer > interval)
        {
            Instantiate(asteroidPrefab, RandomPointInBox(), asteroidPrefab.transform.rotation);
            spawnTimer = 0;
        }
    }

    Vector3 RandomPointInBox()
    {
        Vector3 randomPoint = new Vector3(
            Random.Range(myCollider.bounds.min.x, myCollider.bounds.max.x),
            Random.Range(myCollider.bounds.min.y, myCollider.bounds.max.y),
            0);
        
        return randomPoint;
    }
}
