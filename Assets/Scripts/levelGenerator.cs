using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    public int width = 3;
    public int height = 3;

    public gridElement gridElement;
    public gridElement[] gridElements;
    
    void Start()
    {
        //初始化列表，列表长度为方块的长宽高
        gridElements = new gridElement[width * width * height];
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < width; z++)
                {
                    //实例化格子；将格子命名；将格子按顺序放置与列表中
                    gridElement gridElementInstance = Instantiate(gridElement, new Vector3(x,y,z), Quaternion.identity, this.transform);
                    gridElementInstance.name = "GridElement_" + x + "_" + y + "_" + z;
                    gridElements[x + width * (z + width * y)] = gridElementInstance;
                }
            }
        }
    }
    
}
