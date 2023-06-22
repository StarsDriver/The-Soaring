using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHitControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1, 0) * 30 * Time.deltaTime);
        Destroy(gameObject, 10f);
    }
}
