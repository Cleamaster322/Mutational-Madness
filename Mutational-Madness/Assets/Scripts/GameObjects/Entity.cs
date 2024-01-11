using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Yeah i know it's small but it's useful and i mean it
    public int health;

    public virtual void TakeDamage(int damage)
    {
        health -= damage;    
    }

}

