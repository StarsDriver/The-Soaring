using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoetryControl : MonoBehaviour
{
    private GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        FollowCamera();
    }
    private void FollowCamera()
    {
        transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, 0);
        //不能直接等于摄像机坐标,z方向需拉开一定距离
    }
}
