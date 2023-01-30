using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject Player;

    public float ObjectSpeed = 10;
    public Transform[] Positions;
    public Transform NextPos;

    public bool Activated = false;

    int NextPosIndex;

    public float TimeLeft;
    public bool TimerOn = false;

    float RandomInvoke;


    void Awake()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Positions = new Transform[spawnLocations.Length];
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            Positions[i] = spawnLocations[i].transform;
        }
        NextPos = Positions[1];
        //Debug.Log($"{Positions.Length.ToString()} Positions(s) found.");
    }

    // Start is called before the first frame update
    void Start()
    {
        Timer();
    }

    // Update is called once per frame
    void Update()
    {
        RandomCase();
        StartCoroutine(TimeDelay());
    }

    void Slide()
    {
        Activated = true;
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");

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
        
        Activated = false;
      
    }  
        //Debug.Log("Slide!");


    void Timer()
    {
        TimerOn = true;
        float number = Random.Range(1, 5);
        float number2 = Random.Range(1, 10);
        TimeLeft = number;
        RandomInvoke = number2;
        //Debug.Log("Random TimeLeft =  " + TimeLeft.ToString());
        //Debug.Log("wait time = " + RandomInvoke.ToString());
    }

    void Teleport()
    {
        Activated = true;
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
        NextPosIndex = Random.Range(0, spawnLocations.Length);
        NextPos = Positions[NextPosIndex];
        Player.transform.position = NextPos.transform.position;
        //Debug.Log("Teleport!");
        
        Activated = false;
    }

    void RandomCase()
    {
        int randomCase = Random.Range(1, 3);
        switch (randomCase)
        {
            case 1:
                if (TimerOn == true && Activated == false)
                {
                    
                    Slide();
                    if (TimeLeft > 0)// && Activated == false)
                    {
                        TimeLeft -= Time.deltaTime;
                    }
                    else
                    {
                        
                        TimeLeft = 0;
                        TimerOn = false;

                        Invoke("Timer", RandomInvoke);
                    }
                }
                
                break;
            case 2:
                if (TimerOn == true && Activated == false)
                {   
                    if (TimeLeft > 0)// && Activated == false)
                    {
                        TimeLeft -= Time.deltaTime;
                    }
                    else
                    {
                        Teleport();
                        TimeLeft = 0;
                        TimerOn = false;

                        Invoke("Timer", RandomInvoke);
                    }
                }
                
                break;
        }
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(3);
    }

}
