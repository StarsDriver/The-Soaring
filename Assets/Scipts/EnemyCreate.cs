using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour//用于生成敌对大鱼
{
    public GameObject Enemy;
    public GameObject Turtle;
    private GameObject Fish;
    private Fish FishScene;
    private float timer=0;
    private float timer2 = 0;
    //用于计算冷却时间
    void Start()
    {
        Fish = GameObject.FindGameObjectWithTag("Player");
        FishScene = Fish.GetComponent<Fish>();//获取玩家物体上脚本组件
    }

    // Update is called once per frame
    void Update()
    {
        if (FishScene.SceneNum == 0)//若玩家处于第一个场景则生成敌鱼
        {
            timer += Time.deltaTime;
            timer2+=Time.deltaTime;
            if (Fish != null)
            {
                while (timer > 5)//到达冷却时间
                {
                    Instantiate(Enemy, new Vector2(Fish.transform.position.x + Random.Range(60, 80), Random.Range(-17.07f, -2.78f)), Quaternion.Euler(0, 180, 0));
                    //生成一个大鱼
                    timer = 0;
                }
            }
            if(Fish!=null)
            {
                while(timer2>4)
                {
                    Instantiate(Turtle, new Vector2(Fish.transform.position.x + Random.Range(60, 80), Random.Range(-17.07f, -2.78f)), Quaternion.Euler(0, 0, 0));
                    //生成一个龟
                    timer2 =0;
                }
            }
        }
    }
   
}
