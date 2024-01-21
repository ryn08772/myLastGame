using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerObtainScrpit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position,3.0f,Vector3.forward);
    }
}
