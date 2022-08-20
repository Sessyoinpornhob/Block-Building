using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cornerElement : MonoBehaviour
{
    private coord _coord;

    public void Initialize(int setX, int setY, int setZ)
    {
        _coord = new coord(setX, setY, setZ);
        this.name = "CE_" + _coord.x + "_" + _coord.y + "_" + _coord.z;
    }
}
