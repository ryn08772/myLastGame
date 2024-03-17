using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        transform.DORotate(new Vector3(0, 90, 0), 2f);
        transform.DOMove(this.transform.position + new Vector3(0.4f, 0, -0.4f), 2f);
    }
}
