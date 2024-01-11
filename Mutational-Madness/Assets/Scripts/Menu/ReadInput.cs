using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    //That's for eggs
    private string input;
    public GameObject PanSan;
    public GameObject gg;
    public GameObject Trent;
   
    public void ReadStringInput(string s)
    {
        input = s;
        if (input == "PanSan!")
        {
            Trent.SetActive(false);
            gg.SetActive(false);
            PanSan.SetActive(true);
        }
        

        if (input == "Wham!")
        {
            PanSan.SetActive(false);
            gg.SetActive(false);
            Trent.SetActive(true);
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=E8gmARGvPlI");
        }
    }
}
