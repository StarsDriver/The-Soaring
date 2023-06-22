using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesControl : MonoBehaviour
{
    private Transform UpWaves;
    private Transform DownWaves;
    private float timer1 = 0.5f;//两个计时器，对应上下波
    private float timer2 = 0;
    private bool IsZero1=false;//判断该计时器是否已被重置
    private bool IsZero2=false;
    private float CD=1;//水波变换方向的间隔时间
    private float velocity = 2f;//水波移动速度
    void Start()
    {
        UpWaves = transform.Find("Up");
        DownWaves = transform.Find("Down");
    }

    // Update is called once per frame
    void Update()
    {
        timer1 += Time.deltaTime;//采用双计时器来保持不断改变的运动状态
        timer2+=Time.deltaTime;
        if(timer1>CD)
        {
            IsZero1 = false;
            UpWaves.Translate(new Vector2(0,1)* velocity * Time.deltaTime);
            DownWaves.Translate(new Vector2(0,-1)* velocity * Time.deltaTime);
            if (!IsZero2)//若已被重置过则不再重置
            {
                timer2 = 0;
                IsZero2= true;
            }
        }
        if(timer2>CD)
        {
            IsZero2= false;
            UpWaves.Translate(new Vector2(0, -1) * velocity * Time.deltaTime);
            DownWaves.Translate(new Vector2(0, 1) * velocity * Time.deltaTime);
            if (!IsZero1)
            {
                timer1 = 0;
                IsZero1 = true;
            }
        }
    }
}
