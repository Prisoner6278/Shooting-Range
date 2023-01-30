 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHealth : MonoBehaviour
{
    public static int life = 100;

    Text HealthText;

    // Start is called before the first frame update
    void Start()
    {
        HealthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health: " + life;
        if (life < 0)
        {
            life = 100;
            SceneManager.LoadScene("GameOver");
            //Debug.Log("Game Over");
        }
    }

    public void TakeDamage(int amount)
    {
        life -= amount;
    }
}
