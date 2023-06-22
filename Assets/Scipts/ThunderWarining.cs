using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderWarining : MonoBehaviour
{
    private GameObject MainCamera;
    public GameObject Thunder;
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //摄像机中途无更换，用此判断角色与其距离
    }

    // Update is called once per frame
    void Update()
    {
        if(MainCamera.transform.position.x-transform.position.x>-20)
        {
            Thunder=Instantiate(Thunder,transform.position,Quaternion.Euler(0,0,-41));
            Destroy(gameObject);
        }
    }
}
