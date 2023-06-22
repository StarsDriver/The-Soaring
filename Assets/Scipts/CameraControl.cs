using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject Player;
    private Fish FishSceneNum;
    private Bird BirdSceneNum;
    void Start()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");//获取玩家物体
        FishSceneNum = Player.GetComponent<Fish>();//用于获取场景序号
        
    }

    void LateUpdate()
    {
        
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");//获取玩家物体
            BirdSceneNum = Player.GetComponent<Bird>();//用于获取场景序号
            FishSceneNum = null;
        }
        if (FishSceneNum != null)//存在鱼
        {
            switch (FishSceneNum.SceneNum)
            {
                case 0:
                case 1:
                    transform.position = new Vector3(Player.transform.position.x + 3, -4.06f, -10);//摄像机x坐标与玩家x坐标对应
                    break;
                case 2:
                    transform.position = new Vector3(Player.transform.position.x + 3, -4.06f, -10);
                    break;
                case 3:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break; 
            }
        }
        else if (FishSceneNum == null)//鱼不存在
        {
        

        switch (BirdSceneNum.SceneNum)
            {
                case 3:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break;
                case 4:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break;
                case 5:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break;
                case 6:
                    transform.position = new Vector3(Player.transform.position.x + 3, 184.43f, -10);
                    break;
                case 7:
                    transform.position = new Vector3(Player.transform.position.x + 3, 184.43f, -10);
                    break;
                case 8:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break;
                case 9:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break;



        }
        }


    }
}
