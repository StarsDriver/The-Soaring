using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private bool FirstFly = true;//刚刚化为鹏,为测试**********************************************
    private bool FirstScene5 = true;//刚进入场景5*********************
    private int SpreadNum = 0;//场景5挥翅膀的次数
    private Vector2 StartControlPoint = new Vector2(277.04f, 32.55f);//可以开始正常控制的点
    private Vector2 Scene5ControlPoint = new Vector2(432.5f, 32.4f);
    private Vector2 dir = new Vector2();
    private Animator ani;
    private Rigidbody2D rb;
    public int SceneNum=3;//记录当前游戏场景，初始为3,为方便测试先设为4*****************************
    public GameObject WaterHit;//被击起的水
    public GameObject Head;//头部，让其与身体一起旋转
    bool Finish = false;//Scene9判断是否播放完动画
    bool Finish2=false;
    /*
     * Scene3:大鹏鸟刚生成
     * Scene4:开始操作大鹏鸟
     * Scene5:水击三千里，抟扶摇而上
     * Scene6:去以六月息者也
     * Scene7:穿过狂风骤雨雷电
     * Scene8飞越大椿
     * Scene9尾声
     */
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        SceneNum = 3;//鸟刚生成时的场景**********************
    }
    void Update()
    {
        
       switch(SceneNum)
        {
            case 3:
                if (FirstFly)
                {
                    ani.SetTrigger("Fly");
                    transform.position = Vector2.MoveTowards(transform.position, StartControlPoint, 5 * Time.deltaTime);
                    //刚化为鹏时，先向远处飞
                    if (transform.position.y - StartControlPoint.y > -0.1)
                    {
                        FirstFly = false;//到达目的地
                    }
                }
                else if (!FirstFly)//正常操控
                {
                    dir = DirDecide();
                    Fly(dir);
                }
            break;
            case 4:
                dir = DirDecide();
                Fly(dir);;
                BoundaryTreatment(49.63f, 15.9f, 265.06f,449.2f);//上边界，下边界，左边界，右边界
                break;
            case 5://水击三千里，抟扶摇而上
                if (FirstScene5)//先飞到指定位置
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);//保持姿态
                    transform.position = Vector2.MoveTowards(transform.position, Scene5ControlPoint, 5 * Time.deltaTime);
                    if (transform.position.x - Scene5ControlPoint.x > -0.1)
                    {
                        FirstScene5 = false;
                    }
                }
                else if (!FirstScene5)
                {
                    if (SpreadNum < 3)//按三次空格
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            ani.SetTrigger("SpreadWings");
                            SpreadNum++;
                            rb.AddForce(new Vector2(0, 1) * SpreadNum * 2000);
                            HitWater(SpreadNum);

                        }
                    }
                    if (SpreadNum == 3)
                    {
                        transform.Translate(new Vector2(0, 1) * 10 * Time.deltaTime);//乘风而上
                        ani.SetTrigger("SpreadWings");
                    }

                }
            break;
            case 6://去以六月息者也
                if (Input.GetAxis("Vertical") > 0)
                {
                    transform.Translate(new Vector2(0, 1) * 10 * Time.deltaTime);
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    transform.Translate(new Vector2(0, -1) * 10 * Time.deltaTime);
                }
                BoundaryTreatment(193.82f, 171.9f, 410f);
                break;
            case 7://穿越暴雨
                dir = DirDecide();
                Fly(dir);
                BoundaryTreatment(193.82f, 171.9f, 410f);
                break;
            case 8://飞越大椿
                dir = DirDecide();
                Fly(dir);
                BoundaryTreatment(372.3f, 184.52f, 873.76f, 898.3f);
                break;
            case 9://尾声
                transform.rotation = Quaternion.Euler(0, 0, 0);//保持姿态
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(1024.69f, 349.16f), 10 * Time.deltaTime);
                if(transform.position.x-1021.6f>-30&&!Finish)
                {
                    ani.SetTrigger("Land");                   
                    Finish = true;
                }
                if(transform.position.x-1021.6>-1&&!Finish2)
                {
                    Head.GetComponent<Animator>().SetTrigger("Head2");
                    Finish2= true;
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
            Head.GetComponent<SpriteRenderer>().flipX = false;//头不翻转
            transform.rotation = Quaternion.Euler(0, 0, 30 * vertical);//旋转

        }
        else if (horizontal < 0)//向反面
        {
            GetComponent<SpriteRenderer>().flipX = true;//翻转
            Head.GetComponent<SpriteRenderer>().flipX = true;//头翻转
            transform.rotation = Quaternion.Euler(0, 0, 30 * (-1) * vertical);//旋转

        }
        Vector2 dir = new Vector2(horizontal, vertical);//朝向

        return dir;

    }
    private void Fly(Vector2 dir)//飞翔的方法
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(dir * 2500);
            ani.SetTrigger("Fly");//播放飞翔动画           
            if(SceneNum==1)
            {

            }
        }
    }
    private void BoundaryTreatment(float top,float bottom,float left)//用于处理物体到达边界的方法,水平移动
    {
        if (transform.position.y >top)//物体到达上端
        {
            transform.position = new Vector3(transform.position.x, top);
        }
        else if (transform.position.y < bottom)//到达场景下端
        {
            transform.position = new Vector3(transform.position.x, bottom);
        }
        else if (transform.position.x <= left)//物体到达左边界
        {
            transform.position = new Vector3(left, transform.position.y);
        }

    }
    private void BoundaryTreatment(float top, float bottom, float left,float right)
    {
        if (transform.position.y > top)//物体到达上端
        {
            transform.position = new Vector3(transform.position.x, top);
        }
        else if (transform.position.y < bottom)//到达场景下端
        {
            transform.position = new Vector3(transform.position.x, bottom);
        }
        else if (transform.position.x <= left)//物体到达左边界
        {
            transform.position = new Vector3(left, transform.position.y);
        }else if(transform.position.x> right)
        {
            transform.position = new Vector3(right, transform.position.y);
        }
    }
    private void HitWater(int SpreadTime)//“击水效果”
    {
        for (int i = 0; i < SpreadTime * 5; i++)
        {
            Instantiate(WaterHit, new Vector2(Random.Range(transform.position.x - 30, transform.position.x - 10), transform.position.y - 15 - i*3), Quaternion.Euler(0, 0, -90));
        }
        for (int i = 0; i < SpreadTime * 5; i++)
        {
            Instantiate(WaterHit, new Vector2(Random.Range(transform.position.x + 10, transform.position.x + 30), transform.position.y - 15 - i * 3), Quaternion.Euler(0, 0, -90));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GoNewScene")
        {
            SceneNum++;
            Destroy(collision.gameObject);//防止再次碰到
        }
        if (collision.tag == "Wind")
        {
            rb.AddForce(new Vector2(1, 0)*3000);//去以六月息者也
            ani.SetTrigger("Fly");
            Destroy(collision.gameObject);
        }
        if(collision.tag=="Enemy")//碰到雷电
        {
            rb.AddForce(new Vector2(-1, 0) * 2500);
        }
        if (collision.tag == "BecomeBird")
        {
            Destroy(collision.gameObject);
        }
    }
}
