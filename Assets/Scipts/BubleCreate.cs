using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleCreate : MonoBehaviour
{
    public GameObject buble1;
    public GameObject buble2;
    public GameObject buble3;
    private GameObject Player;
    private float timer = 0;
    private float CD=1;
    GameObject[] bubles;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player!=null)
        {
            GameObject[] bubles = { buble1, buble2, buble3 };
            timer +=Time.deltaTime;
            if(timer>CD)
            {
                timer = 0;
                CD = Random.Range(1,3);
                for(int i=0;i<6;i++)
                {
                    Instantiate(bubles[(int)Random.Range(0, 3)],new Vector2(Random.Range(Player.transform.position.x-20,Player.transform.position.x+40),-14.16f),Quaternion.Euler(0,0,0));
                }
            }
        }
    }
}
