using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrutleControl : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector2(-1,0)*Random.Range(1,3)*Time.deltaTime);
        Destroy(gameObject,20);
    }
}
