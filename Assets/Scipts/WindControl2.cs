using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindControl2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -1) * 10 * Time.deltaTime);
        Destroy(gameObject,3f);
    }
}
