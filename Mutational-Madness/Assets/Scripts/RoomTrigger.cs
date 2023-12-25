using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationZone : MonoBehaviour
{
    public GameObject[] enemies;
    public float fallSpeed = 1f;
    private int flag;

    private void Start()
    {
        foreach (var enemy in enemies)
        {
            enemy.SetActive(false);
            flag = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (flag == 0 & other.gameObject.CompareTag("Player"))
        {
            flag = 1;
            foreach (var enemy in enemies)
            {              
                    enemy.SetActive(true);        
            }
        }
    }

    
}
