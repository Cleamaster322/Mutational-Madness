using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Memento
{
    public PlayerMemento playerState;
    public List<EnemyMemento> enemyStates;
    public List<ActivationZoneMemento> activationZoneStates;
}

