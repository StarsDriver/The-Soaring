using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCreate2 : MonoBehaviour
{
    public GameObject Wind;
    private GameObject Player;
    public GameObject Scene6;
    public GameObject Scene7;
    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Scene6==null)
        {
            timer += Time.deltaTime;
            Player = GameObject.FindGameObjectWithTag("Player");
            if(timer>1)
            {
                timer = 0;
                Instantiate(Wind,new Vector2(Random.Range(Player.transform.position.x -20, Player.transform.position.x - 16),Random.Range(174,193)),Quaternion.Euler(180,0,90));
            }
        }
        if(Scene7==null)
        {
            Destroy(gameObject);
        }
    }
}
