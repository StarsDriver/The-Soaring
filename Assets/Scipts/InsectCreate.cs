using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectCreate : MonoBehaviour
{
    public GameObject Scene8;
    public GameObject Scene9;
    private GameObject Player;
    public GameObject Insect;
    private float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Scene8 == null)
        {
            timer += Time.deltaTime;
            Player = GameObject.FindGameObjectWithTag("Player");
            if (timer > 3)
            {
                timer = 0;
                Instantiate(Insect, new Vector2(Random.Range(Player.transform.position.x - 10, Player.transform.position.x + 10), Player.transform.position.y + 15), Quaternion.Euler(0, 0, Random.Range(-90, 90)));
            }
        }
        if(Scene9 == null)
        {
            Destroy(gameObject);
        }
    }
}
