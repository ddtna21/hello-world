using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public GameObject MonstersPrefab;                                    //The column game object.
    public int monstersPoolSize = 5;                                    //How many columns to keep on standby.
    public float spawnRate = 2f;                                    //How quickly columns spawn.
    public float monstersMin = -1f;                                    //Minimum y value of the column position.
    public float monstersMax = 3.5f;                                    //Maximum y value of the column position.

    private GameObject[] monsters;                                    //Collection of pooled columns.
    private int currentMonsters = 0;                                    //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2(-10, -15);        //A holding position for our unused columns offscreen.
    private float spawnXPosition = 4f;

    private float timeSinceLastSpawned;

    
    void Start()
    {
        timeSinceLastSpawned = 0f;

        //Initialize the columns collection.
        monsters = new GameObject[monstersPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < monstersPoolSize; i++)
        {
            //...and create the individual columns.
            monsters[i] = (GameObject)Instantiate(MonstersPrefab, objectPoolPosition, Quaternion.identity);
        }
        InvokeRepeating("MonsterPool", 2.0f, 0.3f);
    }
    

    //This spawns columns as long as the game is not over.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            //Set a random y position for the column
            float spawnYPosition = Random.Range(monstersMin, monstersMax);

            //...then set the current column to that position.
            monsters[currentMonsters].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentMonsters++;

            if (currentMonsters >= monstersPoolSize)
            {
                currentMonsters = 0;
                Destroy(gameObject);
            }
        }
    }
}
