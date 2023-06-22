using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCreate : MonoBehaviour
{
    private float top = 200;
    public GameObject Rain;
    private GameObject Player;
    public GameObject Scene7;
    public GameObject Scene8;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Scene7 == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            timer += Time.deltaTime;
            if (timer > 0.004)
            {
                timer = 0;
                Instantiate(Rain, new Vector2(Random.Range(Player.transform.position.x - 25, Player.transform.position.x + 100), top), Quaternion.Euler(0, 0, 0));
            }
        }
        if(Scene8 == null)
        {
            Destroy(gameObject);
        }
    }
}
