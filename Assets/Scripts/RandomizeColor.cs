using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColor : MonoBehaviour
{
    void Start()
    {
        var r = GetComponent<SpriteRenderer>();
        var h = 0.3f;
        r.color = Random.ColorHSV(h, h + 0.1f, 0.6f, 0.7f, 0.7f, 0.8f);
    }
}
