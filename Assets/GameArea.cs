using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    public static GameArea Instance { get; private set; }
    BoxCollider2D bounds;

    public Bounds area;
    
    private void Awake() {
        Instance = this;
        bounds = GetComponent<BoxCollider2D>();
    }

    void Update() {
        area = bounds.bounds;
    }
}
