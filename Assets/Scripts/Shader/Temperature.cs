using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// Ace 
/// </summary>
public class Temperature : MonoBehaviour
{

    float row = 128;//行数
    float col = 128;//列数
    void Start()
    {
        //宽度为列数 高度为行数
        Texture2D t = new Texture2D((int)col, (int)row);
        Color[] colors = new Color[(int)row * (int)col];
        for (int i = 0; i < colors.Length; i++)
        {
            float[] uv = new float[2];
            uv[0] = ((i % col) + 1) / col;
            uv[1] = ((i / col) + 1) / row;
            float temp = computerTemperature(uv);

            if (temp >= 60)
            {
                colors[i] = new Color((temp - 60) / 40 + 1 - (temp - 60) / 40, 1 - (temp - 60) / 40, 0);
            }
            else if (temp >= 30)
            {
                colors[i] = new Color((temp - 30) / 30, (temp - 30) / 30 + 1 - (temp - 30) / 30, 0);
            }
            else
            {
                colors[i] = new Color(0, (temp) / 30, 1 - (temp) / 30);
            }
        }
        t.SetPixels(colors);
        t.Apply();
        GetComponent<Renderer>().material.mainTexture = t;
    }
    [SerializeField]
    PData[] datas = new PData[] { };
    float computerTemperature(float[] uv)
    {

        float d1 = Mathf.Sqrt(uv[0] * uv[0] + uv[1] * uv[1]);
        float d2 = Mathf.Sqrt((1 - uv[0]) * (1 - uv[0]) + (1 - uv[1]) * (1 - uv[1]));
        float d3 = Mathf.Sqrt(uv[0] * uv[0] + (1 - uv[1]) * (1 - uv[1]));
        float d4 = Mathf.Sqrt((1 - uv[0]) * (1 - uv[0]) + uv[1] * uv[1]);
        float m = 1 / d1 + 1 / d2 + 1 / d3 + 1 / d4;
        float n = 1 / d1 * 30 + 1 / d2 * 30 + 1 / d3 * 30 + 1 / d4 * 30;
        for (int i = 0; i < datas.Length; i++)
        {
            float dp = Mathf.Sqrt((uv[0] - datas[i].x) * (uv[0] - datas[i].x) + (uv[1] - datas[i].y) * (uv[1] - datas[i].y));
            m = m + 1 / dp;
            n = n + 1 / dp * datas[i].t;
        }
        return n / m;
    }
}
[Serializable]
public class PData
{
    public float x;
    public float y;
    public float t;
}
