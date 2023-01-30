using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float TimeLimit = 10;

    public AudioSource GunHit;

    public int hit = 0;

    public GameObject[] spawnLocations;

    int NextPosIndex;

    public float ObjectSpeed = 10;
    public Transform[] Positions;
    public Transform NextPos;

    // Start is called before the first frame update
    void Awake()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("EnF");
        Positions = new Transform[spawnLocations.Length];
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            Positions[i] = spawnLocations[i].transform;
        }
        NextPos = Positions[1];
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("Player(Clone)");
        transform.LookAt(obj.transform);
        Slide();
        Timer();
        
    }

    void Timer()
    {
        TimeLimit -= Time.deltaTime;
        if (TimeLimit < 0)
        {
            UIHealth.life -= 50;
            Destroy(gameObject);
            GameObject GCObject = GameObject.FindGameObjectWithTag("GameController");
            CheckEnemy checkEnemyScript = GCObject.GetComponent<CheckEnemy>();
            checkEnemyScript.EnemyDestroyed(this);
            TimeLimit = 5;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GunHit.Play();
            UIScore.score += 25;
            TimeLimit = 5;
            hit += 1;

            if (hit == 3)
            {
                Destroy(gameObject);
                GameObject GCObject = GameObject.FindGameObjectWithTag("GameController");
                CheckEnemy checkEnemyScript = GCObject.GetComponent<CheckEnemy>();
                checkEnemyScript.EnemyDestroyed(this);
            }
        }
    }

    void Slide()
    {
       
        spawnLocations = GameObject.FindGameObjectsWithTag("EnF");

        if (transform.position == NextPos.position)
        {
            NextPosIndex = Random.Range(0, spawnLocations.Length);
            if (NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);

        }
    }

}
