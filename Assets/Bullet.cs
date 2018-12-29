using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 speed = Vector3.up;
    public float angularSpeed = 0.0f;
    public int target = 0;
    
    public Color color;
    
    void Start() {
        var renderer = GetComponentInChildren<SpriteRenderer>();
        renderer.color = color;
    }

    void FixedUpdate()
    {
        this.transform.position += speed * Time.deltaTime;
        var rotz = transform.rotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(0, 0, rotz + angularSpeed * Time.deltaTime);  
    }
}
