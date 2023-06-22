using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCreate : MonoBehaviour
{
    public GameObject Thunder;
    public GameObject Scene7;
    public GameObject Scene8;
    private float timer;
    private GameObject Player;
    private GameObject aThunder;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Scene7==null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            timer += Time.deltaTime;
            if(timer>3.5)
            {
                timer = 0;
                Instantiate(Thunder, new Vector2(Random.Range(Player.transform.position.x-5,Player.transform.position.x+20),193), Quaternion.Euler(0, 0, -41));
            }
        }
        if(Scene8==null)
        {
            Destroy(gameObject);
        }
    }
}
