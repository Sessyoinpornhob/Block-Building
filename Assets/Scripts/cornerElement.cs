using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cornerElement : MonoBehaviour
{
    private coord _coord;
    public gridElement[] nearGridElements = new gridElement[8];
    public int bitMaskValue;

    public void Initialize(int setX, int setY, int setZ)
    {
        _coord = new coord(setX, setY, setZ);
        this.name = "CE_" + _coord.x + "_" + _coord.y + "_" + _coord.z;
    }

    public void SetPosition(float setX, float setY, float setZ)
    {
        this.transform.position = new Vector3(setX, setY, setZ);
    }

    public void SetCornerElement()
    {
        bitMaskValue = bitMask.GetBitMask(nearGridElements);
    }

    public void SetNearGridElements()
    {
        int width = levelGenerator.instance.width;
        int height = levelGenerator.instance.height;
        
        if (_coord.x < width && _coord.y < height && _coord.z < width)
        {
            //上 东 北 00000001 1
            nearGridElements[0] = levelGenerator.instance.gridElements[_coord.x + width * (_coord.z + width * _coord.y)];
        }
        if (_coord.x > 0 && _coord.y < height && _coord.z < width)
        {
            //上 西 北 00000010 2
            nearGridElements[1] = levelGenerator.instance.gridElements[_coord.x-1 + width * (_coord.z + width * _coord.y)];
        }
        if (_coord.x > 0 && _coord.y < height && _coord.z > 0)
        {
            //上 西 南 00000100 4
            nearGridElements[2] = levelGenerator.instance.gridElements[_coord.x-1 + width * (_coord.z-1 + width * _coord.y)];
        }
        if (_coord.x < width && _coord.y < height && _coord.z > 0)
        {
            //上 东 南 00001000 8
            nearGridElements[3] = levelGenerator.instance.gridElements[_coord.x + width * (_coord.z-1 + width * _coord.y)];
        }
        if (_coord.x < width && _coord.y > 0 && _coord.z < width)
        {
            //下 东 北 00010000 16
            nearGridElements[4] = levelGenerator.instance.gridElements[_coord.x + width * (_coord.z + width * (_coord.y-1))];
        }
        if (_coord.x > 0 && _coord.y > 0 && _coord.z < width)
        {
            //下 西 北 00100000 32
            nearGridElements[5] = levelGenerator.instance.gridElements[_coord.x-1 + width * (_coord.z + width * (_coord.y-1))];
        }
        if (_coord.x > 0 && _coord.y > 0 && _coord.z > 0)
        {
            //下 西 南 01000000 64
            nearGridElements[6] = levelGenerator.instance.gridElements[_coord.x-1 + width * (_coord.z-1 + width * (_coord.y-1))];
        }
        if (_coord.x < width && _coord.y > 0 && _coord.z > 0)
        {
            //下 东 南 10000000 128
            nearGridElements[7] = levelGenerator.instance.gridElements[_coord.x + width * (_coord.z-1 + width * (_coord.y-1))];
        }
        
    }
}
