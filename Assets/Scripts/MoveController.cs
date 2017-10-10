using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveController : MonoBehaviour
{

    void OnEnable()
    {
//        EasyJoystick.On_JoystickMove += OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
    }
    /// <summary>
    /// 移动摇杆结束
    /// </summary>
    /// <param name="move"></param>
    void OnJoystickMoveEnd(MovingJoystick move)
    {
        //停止时,角色恢复idle
        if (move.joystickName == "MoveJoystick")
        {
            GetComponent<Animation>().CrossFade("idle");
        }
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
