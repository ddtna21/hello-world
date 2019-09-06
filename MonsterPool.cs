using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public GameObject CoinsPrefab;                                    
    public int coinsPoolSize = 5;                                   
    public float spawnRate = 2f;                                    
    public float coinsMin = -1f;                                    
    public float coinsMax = 3.5f;                                   

    private GameObject[] coins;                                    
    private int currentCoins = 0;                                    

    private Vector2 objectPoolPosition = new Vector2(-10, -15);        
    private float spawnXPosition = 4f;

    private float timeSinceLastSpawned;

    
    void Start()
    {
        timeSinceLastSpawned = 0f;

        
        coins = new GameObject[coinsPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < coinsPoolSize; i++)
        {
            
            coins[i] = (GameObject)Instantiate(CoinsPrefab, objectPoolPosition, Quaternion.identity);
        }
        InvokeRepeating("CoinPool", 2.0f, 0.3f);
    }
    

    .
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            
            float spawnYPosition = Random.Range(coinsMin, coinsMax);

         
            coins[currentCoins].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            
            currentCoins++;

            if (currentCoins >= coinsPoolSize)
            {
                currentCoins = 0;
                Destroy(gameObject);
            }
        }
    }
}
