using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject Verse1;//北冥有鱼
    public GameObject Scene3;
    public GameObject Verse2;//化而为鸟
    public GameObject Scene5;
    public GameObject Verse3;//水击三千里，抟扶摇而上者九万里
    public GameObject Scene6;
    public GameObject Verse4;//去以六月息者也
    public GameObject Scene8;
    public GameObject Verse5;//上古有大椿者
    public GameObject Scene9;//检测进入尾声
    private GameObject Camera;
    public GameObject South;//提示到达南冥
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Camera.transform.position.x,Camera.transform.position.y,Camera.transform.position.z+10);
        if(Scene3==null)
        {
            Verse2.SetActive(true);
        }
        if(Scene5==null)
        {
            Verse3.SetActive(true);
        }
        if(Scene6==null)
        {
            Verse4.SetActive(true);
        }
        if(Scene8==null)
        {
            Verse5.SetActive(true);
        }
        if(Scene9==null)
        {          
             South.SetActive(true);
        }
    }
}
