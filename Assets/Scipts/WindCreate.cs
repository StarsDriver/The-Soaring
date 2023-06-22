using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCreate : MonoBehaviour
{
    public GameObject Scene5;//与场景5的触发器关联，判断何时开始造风
    public GameObject Scene6;//判断何时停止造风
    private GameObject Player;
    public GameObject Wind;
    private float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Scene5==null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            timer += Time.deltaTime;
            if (timer > 2)//生成间隔
            {
                timer = 0;
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(Wind, new Vector2(Random.Range(407.3f, 446f), Player.transform.position.y-Random.Range(16,20)), Quaternion.Euler(0,0,180));
                }
            }
        }
        //if (Scene6 == null) ;
    }
}
