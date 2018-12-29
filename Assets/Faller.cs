using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Faller : MonoBehaviour
{
    public float speed = 1.0f;
    public float health = 3.0f;
    public int   target = 0;

    AudioSource player;
    void Awake() {
        player = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bullet")
            return;
        
        var bullet = collision.gameObject.GetComponent<Bullet>();
        var correct = bullet.target == target;
        
        player.Play();
        Destroy(collision.gameObject);

        health += correct ? -1.0f : 1.0f;
        transform.localScale *= correct ? 0.7f : 1 / 0.7f;

        if(health <= 0.0f){
            Destroy(gameObject);
        }
    }
}
