using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UniRx;
//[ExecuteInEditMode]
public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
       //RUpdate();
       //OnThrottle();
       IntervalFun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region 时间
    void TimerDelay()
    {
        Debug.Log(" " + Time.realtimeSinceStartup);
        Observable.Timer(TimeSpan.FromSeconds(2)).Subscribe((_next) =>
        {
            Debug.Log(" " + _next + " " + Time.realtimeSinceStartup);
        }).AddTo(this);
    }
    #endregion

    #region 更新

    void RUpdate()
    {
        Observable.EveryUpdate().Where(_=>Input.GetMouseButtonDown(0)).Subscribe(_ =>
        {
            Debug.Log("鼠标按下");
        });
    }

    //每隔一段时间调用
    void IntervalFun()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Delay(TimeSpan.FromSeconds(1.0f))
            .Subscribe(_ => { Debug.Log("mouse clicked"); })
            .AddTo(this);
    }
    #endregion

    #region 条件

    //节流条件
    void OnThrottle()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .Throttle(TimeSpan.FromSeconds(1))
            .Subscribe(_ => Debug.Log("一秒过后"));
    }
    #endregion



}
