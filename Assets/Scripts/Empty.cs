using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : MonoBehaviour
{

    public float TimeLimit = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }
    void Timer()
    {
        TimeLimit -= Time.deltaTime;
        if (TimeLimit < 0)
        {
            Destroy(gameObject);
            GameObject GCObject = GameObject.FindGameObjectWithTag("GameController");
            CheckEnemy checkEnemyScript = GCObject.GetComponent<CheckEnemy>();
            checkEnemyScript.EmptyDestroyed(this);
        }
    }

}
