using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class new_SceneChange : MonoBehaviour {

  //  public string sceneName;
  /// <summary>
  /// 按钮跳转指定场景名字的场景
  /// </summary>
  /// <param name="sceneName"></param>
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
