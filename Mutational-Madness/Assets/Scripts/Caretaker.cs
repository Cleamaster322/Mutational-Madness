using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Caretaker
{
    private Memento memento;

    public void SaveMemento(Memento memento)
    {
        this.memento = memento;
    }

    public Memento LoadMemento()
    {
        return memento;
    }
}

