using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string input;
    public GameObject PanSan;
    public GameObject gg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReadStringInput(string s)
    {
        input = s;
        if (input == "PanSan!")
        {
            gg.SetActive(false);
            PanSan.SetActive(true);
        } 
        if (input == "Wham!")
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=E8gmARGvPlI");
        }
    }
}
