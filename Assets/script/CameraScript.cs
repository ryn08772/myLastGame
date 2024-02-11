using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject obtainView;
    private string ObjectName;
    private int ObjectCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angle = new Vector3(0, Input.GetAxis("Mouse Y") * -rotateSpeed, 0);
        transform.RotateAround(player.transform.position, transform.right, angle.y * sensitivity);
        if (transform.eulerAngles.x < 336 && transform.eulerAngles.x > 30)//この構文で30度以上336度未満という意味になる。
        {
            transform.RotateAround(player.transform.position, transform.right, -angle.y * sensitivity);//33行目をマイナスにすることで動いたことを無かったことにしている。
        }
    }
}
