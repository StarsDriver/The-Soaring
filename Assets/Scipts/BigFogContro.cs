using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFogContro : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector2(0,1)*0.2f*Time.deltaTime);
    }
}
