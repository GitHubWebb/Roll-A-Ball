using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private float x = 0;
    private float y = 1;
    private float z = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //通过transform的Rotate()  是按照某个轴旋转
        transform.Rotate(new Vector3(x, y, z));
    }
}
