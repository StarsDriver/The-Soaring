using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour
{
    private float timer = 0;
    private Animator ani;
    int aniChoice = 1;
    public GameObject Body;
    private Bird bird;//获取身体的脚本组件
    private void Start()
    {
        ani= GetComponent<Animator>();
        bird=Body.GetComponent<Bird>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (bird.SceneNum != 9)
        {
            if (timer > 8)
            {
                timer = 0;
                if (aniChoice == 1)
                {
                    ani.SetTrigger("Head1");
                    aniChoice = -1;
                }
                else if (aniChoice == -1)
                {
                    ani.SetTrigger("Head2");
                    aniChoice = 1;
                }
            }
        }else if(bird.SceneNum==9)
        {
            
        }
    }
}
