using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int levelGenerate;

    GameObject[] enemyList;

    void Start()
    {
        //enemyList = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyDestroyed(Enemy e)
    {
        GameObject enfObject = GameObject.FindGameObjectWithTag("EnF");
        EnF enfControl = enfObject.GetComponent<EnF>();
        enfControl.EoF();
        enfControl.exists = false;
    }

    public void FriendlyDestroyed(Friendly f)
    {
        GameObject enfObject = GameObject.FindGameObjectWithTag("EnF");
        EnF enfControl = enfObject.GetComponent<EnF>();
        enfControl.EoF();
        enfControl.exists = false;
    }

    public void EmptyDestroyed(Empty e)
    {
        GameObject enfObject = GameObject.FindGameObjectWithTag("EnF");
        EnF enfControl = enfObject.GetComponent<EnF>();
        enfControl.EoF();
        enfControl.exists = false;
    }

}
