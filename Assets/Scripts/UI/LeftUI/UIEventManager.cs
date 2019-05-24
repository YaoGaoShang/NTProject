using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIEventManager : MonoBehaviour
{
    /// <summary>
    /// 折叠按钮
    /// </summary>
    public  Button btn_Fold;
    /// <summary>
    /// 关闭按钮
    /// </summary>
    public Button btn_Close;
    public Button btn_CloseInfoPanel;

    public Button btn_Preview;
    public GameObject MenuInfoPanel;
    public void Awake()
    {
       // btn_Fold = GameObject.Find("btn_Fold").GetComponent<Button>();
        btn_Fold.onClick.AddListener(() =>
        {
            UIManager.Instance.UIShow(MenuInfoPanel);
            UIManager.Instance.UIHide(btn_Fold.gameObject);
        }
        );
        btn_Close.onClick.AddListener(() =>
        {
            UIManager.Instance.UIShow(btn_Fold.gameObject);
            UIManager.Instance.UIHide(MenuInfoPanel);
        }
 );
        btn_CloseInfoPanel.onClick.AddListener(
            () =>
            {
                if (InfoShow.Instance.infoMessagePanel.activeInHierarchy)
                {
                    UIManager.Instance.UIHide(InfoShow.Instance.infoMessagePanel);
                }
            }
            );
        btn_Preview.onClick.AddListener(() =>
        {
            if (SceneManager.GetActiveScene().name.Equals(SceneName.EditorScene))
                SceneManager.LoadScene(SceneName.PreviewScene);
            else if (SceneManager.GetActiveScene().name.Equals(SceneName.PreviewScene))
            {
                ServerControl.Instance.SetAllAni();
                SceneManager.LoadScene(SceneName.EditorScene);

            }

        });
    }

}
