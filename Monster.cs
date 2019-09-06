using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //private int score = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Ufo>() != null)
        {
            GameControl.instance.PlaneScored();
            //Destroy(gameObject);
        }
    }
       
}
