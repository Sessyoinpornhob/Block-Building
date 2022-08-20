using UnityEngine;

public class coord
{
    public int x, y, z;
    public coord(int setX, int setY, int setZ)
    {
        x = setX;
        y = setY;
        z = setZ;
    }
}
public class gridElement : MonoBehaviour
{
    private coord _coord;
    private Collider _collider;
    private Renderer _renderer;

    public cornerElement[] corners = new cornerElement[8];

    public void Initialize(int setX, int setY, int setZ)
    {
        _coord = new coord(setX, setY, setZ);
        this.name = "GE_" + this._coord.x + "_" + this._coord.y + "_" + this._coord.z;
        this._collider = this.GetComponent<Collider>();
        this._renderer = this.GetComponent<Renderer>();
    }

    public coord GetCoord()
    {
        return _coord;
    }

    public void SetEnable()
    {
        this._collider.enabled = true;
        this._renderer.enabled = true;
    }

    public void SetDisable()
    {
        this._collider.enabled = false;
        this._renderer.enabled = false;        
    }
}
