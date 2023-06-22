using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReCloudMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(1,0)*0.5f*Time.deltaTime);
        if(transform.position.x>657f)
        {
            Destroy(gameObject);
        }
    }
}
