using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Memento
{
    //i know it's even smaller, but who are u to sue me?
    //memento class for memento saving
    public PlayerMemento playerState;
    public List<EnemyMemento> enemyStates;
    public List<ActivationZoneMemento> activationZoneStates;
}

