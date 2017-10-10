using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    //刚体组件
    private Rigidbody rd;
    //动态控制Vector3
    public int force = 5;
    //分数
    private int score = 0;
    //获取Text组件
    public Text text;
    //获取PickUps
    public GameObject pickUps;
    //胜利
    public GameObject winButton;

    List<String> list = new List<String>();
    float x = 0;
    float y = 0;
    float z = 0;
    // Use this for initialization
    void Start()
    {
        //得到当前游戏物体的Rigidbody 刚体组件
        rd = GetComponent<Rigidbody>();
        foreach (Transform pickUp in pickUps.transform)
        {
            //print(pickUp.name);
            list.Add(pickUp.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal 水平  h 会返回 -1 A   ----   1  D
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        x = h;
        z = v;
        //Debug.Log("x" + x + "y" + y + "z" + z);
        rd.AddForce(new Vector3(x, y, z) * force);

    }
    /// <summary>
    /// 碰撞检测
    /// Unity会去调用,执行
    /// collision 碰撞信息
    /// </summary>
    void OnCollisionEnter(Collision collision)
    {
        //collision.collider//获取碰撞到的游戏物体深山过得Collider组件
        //string name = collision.collider.name;   //获取碰撞到游戏物体的名字
        //print(name);  //print可以把一个字符串输出,显示在控制台
        if (collision.collider.tag == "PickUp")
        {
            Destroy(collision.collider.gameObject);
        }
    }

    /// <summary>
    /// 触发器,跟哪个触发器接触
    /// </summary>
    /// <param name="collider"></param> 
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PickUp")
        {
            score++;
            text.text = "分数:" + score.ToString();


            print(list.Count);
            if (score == list.Count)
            {
                winButton.SetActive(true);
            }
            Destroy(collider.gameObject);

        }
    }

    public void exit()
    {
        //#if UNITY_EDITOR
        //        print("退出");
        //        Application.Quit();
        //#endif
#if UNITY_WEBPLAYER

      string webplayerQuitURL = "http://www.baidu.com";
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif


    }
}
