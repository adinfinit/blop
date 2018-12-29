using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Spawner : MonoBehaviour
{
    BoxCollider2D boundary;

    public GameObject red;
    public GameObject blue;

    public  float spawnInterval  = 5.0f;
    public  float spawnRandomize = 1.0f;
    private float spawnCountdown = 2.0f;

    void Start()
    {
        boundary = GetComponent<BoxCollider2D>();
    }

    void Spawn() {
        var target = red;
        if(Random.Range(0.0f, 1.0f) < 0.5f){
            target = blue;
        }

        var x = Random.Range(boundary.bounds.min.x, boundary.bounds.max.x);
        var y = boundary.bounds.center.y;
        var z = boundary.bounds.center.z;

        var p = new Vector3(x, y, z);
        Instantiate(target, p, new Quaternion());
    }

    void FixedUpdate()
    {
        spawnCountdown -= Time.deltaTime;
        if(spawnCountdown < 0) {
            Spawn();
            spawnCountdown = spawnInterval + Random.Range(0f, spawnRandomize);
        }
    }
}
