using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void Update()
    {
        var area = GameArea.Instance.area;
        var p = transform.position;
        var contained = 
            area.min.x <= p.x && p.x <= area.max.x &&
            area.min.y <= p.y && p.y <= area.max.y;
        
        if(!contained){
            Destroy(gameObject);
        }
    }
}
