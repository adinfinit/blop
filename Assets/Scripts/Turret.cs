using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Spawner spawner;

    public GameObject bullet;
    public float      bulletSpeed = 2.0f;
    public float      bulletRate  = 0.05f;

    public float      swapInterval = 3f;

    float lastFiring = 0.0f;
    float rotzOffset = 0.0f;

    GameObject barrelBase;
    GameObject barrel;
    GameObject barrelEnd;
    GameObject crosshair;

    void Start()
    {
        barrelBase = transform.Find("Base").gameObject;
        barrel = transform.Find("Barrel").gameObject;
        barrelEnd = barrel.transform.Find("End").gameObject;
        crosshair = transform.Find("Crosshair").gameObject;

        rotzOffset = barrel.transform.rotation.eulerAngles.z;
    }

    void FixedUpdate()
    {
        var side = Mathf.Repeat(Time.time, swapInterval) < swapInterval / 2.0f;
        var target = side ? spawner.red : spawner.blue;
        var color = target.GetComponentInChildren<SpriteRenderer>().color;

        barrelBase.GetComponentInChildren<SpriteRenderer>().color = color;
        barrel.GetComponentInChildren<SpriteRenderer>().color = color;

        var cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.z = 0.0f;

        var delta  = cursor - transform.position;
        float rotz = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        
        barrel.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotz - 90.0f + rotzOffset);

        crosshair.transform.position = new Vector3(cursor.x, cursor.y, 0.0f);
        
        if(Time.time - lastFiring < bulletRate) {
            return;
        }

        var fire = Input.GetButton("Fire1");
        if(!fire) return;

        lastFiring = Time.time;

        var b = Instantiate(bullet, barrelEnd.transform.position, new Quaternion());
        var logic =  b.GetComponent<Bullet>();

        logic.color = color;
        logic.target = target.GetComponentInChildren<Faller>().target;

        logic.speed = delta.normalized * bulletSpeed;
        logic.angularSpeed = Random.Range(360.0f, 720.0f);
        if(Random.Range(0, 2) < 1){
            logic.angularSpeed = -logic.angularSpeed;
        }
    }
}
