using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 这个接口是为了管理  LineRenderer  下面的  point的位置
/// </summary>
public interface IPoint  {
    /// <summary>
    /// 设置自身的位置
    /// </summary>
    void SetMySelfPos();

    void SetMySelfPos(Transform  t);

    void SetMySelfPos(Vector3 pos);

}
