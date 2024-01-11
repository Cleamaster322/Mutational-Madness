using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class Caretaker
{
    //caretaker class for memento
    private Memento memento;
    private int currentSlot;

    public void SaveMemento(Memento memento, int slot)
    {
        string path = Path.Combine(Application.persistentDataPath, "save" + slot + ".dat");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        bf.Serialize(file, memento);
        file.Close();
        currentSlot = slot;
        Debug.Log($"Saved game to: {path}");
    }

    public Memento LoadMemento(int slot)
    {
        string path = Path.Combine(Application.persistentDataPath, "save" + slot + ".dat");
        Debug.Log($"Trying to load from: {path}");
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            Memento memento = (Memento)bf.Deserialize(file);
            file.Close();
            currentSlot = slot;
            return memento;
        }
        else
        {
            Debug.Log("File does not exist: " + path);
            return null;
        }
    }

    public int CurrentSlot
    {
        get { return currentSlot; }
    }
}
