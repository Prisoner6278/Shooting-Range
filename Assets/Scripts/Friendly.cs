using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : MonoBehaviour
{
    public int hit = 0;

    public AudioSource FriendlyFIre1;
    public AudioSource FriendlyFIre2;
    public AudioSource FriendlyFIre3;

    public GameObject[] spawnLocations;
    public GameObject Player;

    public float ObjectSpeed = 10;
    public Transform[] Positions;
    public Transform NextPos;

    int NextPosIndex;

    float RandomInvoke;

    public bool Activated = false;

    public float TimeLeft;
    public bool TimerOn = false;

    public float TimeLimit = 5;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            UIScore.score -= 50;
            hit += 1;
            RandomVoice();
            if (hit == 3)
            {
                Destroy(gameObject);

                GameObject GCObject = GameObject.FindGameObjectWithTag("GameController");
                CheckEnemy checkEnemyScript = GCObject.GetComponent<CheckEnemy>();
                checkEnemyScript.FriendlyDestroyed(this);

            }
        }
    }

    void RandomVoice()
    {
        int threeOption = Random.Range(1, 4);
        switch (threeOption)
        {
            case 1:
                FriendlyFIre1.Play();
                break;
            case 2:
                FriendlyFIre2.Play();
                break;
            case 3:
                FriendlyFIre3.Play();
                break;
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

    void Timer()
    {
        TimeLimit -= Time.deltaTime;
        if (TimeLimit < 0)
        {
            Destroy(gameObject);
            GameObject GCObject = GameObject.FindGameObjectWithTag("GameController");
            CheckEnemy checkEnemyScript = GCObject.GetComponent<CheckEnemy>();
            checkEnemyScript.FriendlyDestroyed(this);
        }
    }

}
