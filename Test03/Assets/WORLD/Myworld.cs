using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//需要种子的核心目的：事后可以还原
public class Myworld : MonoBehaviour
{
    public int mapHeight;
    public int mapWidth;
    public float lacunarity = 0.001f;//间隙
    public GameObject tileprefab;//地砖预制体
    public Material[] materials;
    public int tileHeigtMultiply = 1;//砖块高度

    public bool isSmoth;

    public int randomSeed;//随机数
    //生成地图
    public void GenerateMap()
    {
        Random.InitState(randomSeed);//静态类直接初始化
        float randomX = Random.Range(0,10000);
        float randomY = Random.Range(0,10000);

        //清理地图
        for (int i = transform.childCount; i > 0; i--)
        {
            DestroyImmediate(transform.GetChild(i-1).gameObject);
        }
        //生成地图
        for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                float y = Mathf.PerlinNoise(x * lacunarity+randomX, z *lacunarity+randomY)*tileHeigtMultiply;
                if(!isSmoth)
                {
                    y = Mathf.Round(y);
                }
                Vector3 pos = new Vector3(x, y, z);
                GameObject go = Instantiate(tileprefab,transform); //生成预制体
                go.transform.position = pos;//赋值坐标
                go.name = y.ToString();
                if (y > 0.8f * tileHeigtMultiply)
                {
                    go.GetComponent<MeshRenderer>().material = materials[0];
                }
                else if (y > 0.3f * tileHeigtMultiply)
                {
                    go.GetComponent<MeshRenderer>().material = materials[1];
                }
                else
                {
                    go.GetComponent<MeshRenderer>().material = materials[2];
                }
            }
        }
    }
}
