using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pineapple : MonoBehaviour
{
    public enum SyunNoSakanaOishii
    {
        unagi,
        sakana,
        tabetai
    }
    Dictionary<string, int> dic = new Dictionary<string, int>()
        {
            {"unagi",11 },
            {"sakana",12 },
            {"tabetai",13 }
        };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
