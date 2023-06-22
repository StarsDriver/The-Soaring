using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleControl : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector2(0,1)*Random.Range(3,7)*Time.deltaTime);
        Destroy(gameObject, 5f);
    }
}
