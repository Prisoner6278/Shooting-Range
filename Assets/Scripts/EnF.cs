using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnF : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject Friendly;
    public GameObject Empty;

    public int digit;

    public bool exists = false;
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        EoF();
    }

    void Update()
    {

    }


    public void EoF()
    {
        if (exists == false)
        {
            digit = Random.Range(0, 101);

            if (digit <= 35)
            {
                Instantiate(Friendly, transform.position, transform.rotation);
            }
            else if (digit <= 50 && digit > 35)
            {
                Instantiate(Empty, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(Enemy, transform.position, transform.rotation);
            };
        }

        



        //int threeOption = Random.Range(1, 4);
        //switch (threeOption)
        //{
        //    case 1:
        //        Instantiate(Empty, transform.position, transform.rotation);
        //        //GameObject Prefab = Instantiate(Empty, transform.position, transform.rotation);
        //        //Destroy(Prefab);
        //        //int randomNumber = Random.Range(0, 5);
        //        //Invoke("EoF", randomNumber);
        //        break;
        //    case 2:
        //        //GameObject.Instantiate(Enemy, gameObject.transform.position, Quaternion.identity);
        //        Instantiate(Enemy, transform.position, transform.rotation);
        //        break;
        //    case 3:
        //        //GameObject.Instantiate(Friendly, gameObject.transform.position, Quaternion.identity);
        //        Instantiate(Friendly, transform.position, transform.rotation);
        //        break;
        //}
    }
}




