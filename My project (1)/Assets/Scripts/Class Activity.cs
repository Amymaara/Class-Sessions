using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ClassActivity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    void Start()
    {
        int coins;
        coins = 3;

        int coinValue;
        coinValue = 25;
        int totalScore;

        totalScore = coins * coinValue;

        Debug.Log("Total Score: " + totalScore);

        //activity 2

        bool hasKey = true;

        if (hasKey)
        {
            Debug.Log("You have the key");
        }
        else
        {
            Debug.Log("No key :c");
        }

        //activity 3

        int health = 100;
        int damage = 30;

        int currentHealth = health -= damage;

        Debug.Log("Player health: " + currentHealth);



    }

    private void Update()
    {
        float rotationSpeed = 50f;

        transform.Rotate(0,rotationSpeed, 0);
    }
}
