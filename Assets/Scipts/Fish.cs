using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Vector2 dir = new Vector2();
    private Rigidbody2D rb;
    private Animator ani;
    public bool IsTimeToFly=false;//判断变成鹏的时刻
    public GameObject Bird;//鹏
    public int SceneNum = 0;//记录当前场景序号

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//获取物体的刚体组件
        ani = GetComponent<Animator>();//获取物体动画组件
    }

    void Update()
    {
        switch(SceneNum)
        {
            case 0:
                dir = DirDecide();//获取应移动的方向       
                Swim(dir);//向该方向遨游
                BoundaryTreatment();//处理物体到达边界的情况
                break;
            case 1:
                dir = DirDecide();//获取应移动的方向
                BoundaryTreatment();//处理物体到达边界的情况
                Swim(dir);//向该方向遨游
                break;
            case 2:
            case 3:
                dir = DirDecide();
                Swim(dir);
                BoundaryTreatment();
                if (transform.position.y > 22f)//跃到一定高度
                {
                    GetComponent<SpriteRenderer>().flipX = false;//不翻转
                    transform.rotation = Quaternion.Euler(0, 0, 30);//保持姿态
                    Instantiate(Bird, transform.position, transform.rotation);//化为鹏！
                    Destroy(gameObject);
                }
                break;


        }
        
        
    }
    private Vector2 DirDecide()//根据虚拟轴获取按键摁下的方向
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal >= 0)//向正面
        {
            GetComponent<SpriteRenderer>().flipX = false;//不翻转
            transform.rotation = Quaternion.Euler(0, 0, 30 * vertical);//旋转
            
        }else if(horizontal<0)//向反面
        {
            GetComponent<SpriteRenderer>().flipX = true;//翻转
            transform.rotation = Quaternion.Euler(0, 0, 30 * (-1) * vertical);//旋转

        }
        Vector3 dir = new Vector3(horizontal, vertical);//朝向


        return dir;

    }
    private void Swim(Vector2 dir)//遨游的方法
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsTimeToFly)//不该变鹏
            {
                rb.AddForce(dir * 2500);
            }else if(IsTimeToFly)//该变鹏
            {
                rb.AddForce(new Vector2(1,1.7f)* 5000);//可以飞得很高
                SceneNum = 3;
            }
            ani.SetTrigger("Swim");//播放遨游动画
        }
    }
    private void BoundaryTreatment()//用于处理物体到达边界的方法
    {
        switch (SceneNum)
        {
            case 0:
                if (transform.position.y > -1.84f)//物体到达上端
                {
                    transform.position = new Vector2(transform.position.x, -1.84f);
                }
                else if (transform.position.y < -16.72f)//到达场景下端
                {
                    transform.position = new Vector2(transform.position.x, -16.72f);
                }
                else if (transform.position.x < -35.17f)//物体到达左边界
                {
                    transform.position = new Vector2(-35.17f, transform.position.y);
                }
                break;
            case 1:
                if (transform.position.y > -1.84f )//物体到达上端
                {
                    transform.position = new Vector2(transform.position.x, -1.84f);
                }
                else if (transform.position.y < -16.72f)//到达场景下端
                {
                    transform.position = new Vector2(transform.position.x, -16.72f);
                }
                else if (transform.position.x <= -6.5f)//物体到达左边界
                {
                    transform.position = new Vector2(-6.5f, transform.position.y);
                }
                else if (transform.position.x >= 255.6f)//物体到达右边界
                {
                    transform.position = new Vector2(255.6f, transform.position.y);
                }
                break;
            case 2:
                if (transform.position.x >= 255.6f)//物体到达右边界
                {
                    transform.position = new Vector3(255.6f, transform.position.y);
                }
                break;
                if(transform.position.y<-16.72f)//到达下边界
                {
                    transform.position = new Vector2(transform.position.x, -16.72f);
                }
        }
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Enemy")
        {
            rb.AddForce(new Vector2(-1, 0)*2000);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="TimeToFly")//是时候变成鹏了
        {
            IsTimeToFly = true;
            SceneNum=2;
        }
        
        if(other.tag=="GoNewScene")
        {
            SceneNum++;
            Destroy(other.gameObject);//防止再次碰到
        }
        if(other.tag=="BecomeBird")
        {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if(other.tag=="TimeToFly")
        {
            IsTimeToFly= false;
        }
        
    }

}
