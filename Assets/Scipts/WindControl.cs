using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindControl : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(new Vector2(0, -1) * 20 * Time.deltaTime);//生成时转向，所以向下移动
        Destroy(gameObject,2f);
    }
}
