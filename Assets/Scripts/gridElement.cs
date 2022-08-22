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

    private bool isEnabled;
    private float elementHeight;
    public cornerElement[] corners = new cornerElement[8];

    public void Initialize(int setX, int setY, int setZ, float setElementHeight)
    {
        int width = levelGenerator.instance.width;
        int height = levelGenerator.instance.height;
        this.elementHeight = setElementHeight;
        this.transform.localScale = new Vector3(1.0f, elementHeight, 1.0f);
        
        //设置gridElement
        _coord = new coord(setX, setY, setZ);
        this.name = "GE_" + this._coord.x + "_" + this._coord.y + "_" + this._coord.z;
        this._collider = this.GetComponent<Collider>();
        this._renderer = this.GetComponent<Renderer>();
        
        //设置cornerElement
        corners[0] = levelGenerator.instance.cornerElements[_coord.x + (width+1) * (_coord.z + (width+1) * _coord.y)];
        corners[1] = levelGenerator.instance.cornerElements[_coord.x + 1 + (width+1) * (_coord.z + (width+1) * _coord.y)];
        corners[2] = levelGenerator.instance.cornerElements[_coord.x + (width+1) * (_coord.z + 1 + (width+1) * _coord.y)];
        corners[3] = levelGenerator.instance.cornerElements[_coord.x + 1 + (width+1) * (_coord.z + 1 + (width+1) * _coord.y)];
        corners[4] = levelGenerator.instance.cornerElements[_coord.x + (width+1) * (_coord.z + (width+1) * (_coord.y+1))];
        corners[5] = levelGenerator.instance.cornerElements[_coord.x + 1 + (width+1) * (_coord.z + (width+1) * (_coord.y+1))];
        corners[6] = levelGenerator.instance.cornerElements[_coord.x + (width+1) * (_coord.z + 1 + (width+1) * (_coord.y+1))];
        corners[7] = levelGenerator.instance.cornerElements[_coord.x + 1 + (width+1) * (_coord.z + 1 + (width+1) * (_coord.y+1))];
        
        //定位CE
        corners[0].SetPosition(_collider.bounds.min.x, _collider.bounds.min.y, _collider.bounds.min.z);
        corners[1].SetPosition(_collider.bounds.max.x, _collider.bounds.min.y, _collider.bounds.min.z);
        corners[2].SetPosition(_collider.bounds.min.x, _collider.bounds.min.y, _collider.bounds.max.z);
        corners[3].SetPosition(_collider.bounds.max.x, _collider.bounds.min.y, _collider.bounds.max.z);
        //下面一层的ce
        corners[4].SetPosition(_collider.bounds.min.x, _collider.bounds.max.y, _collider.bounds.min.z);
        corners[5].SetPosition(_collider.bounds.max.x, _collider.bounds.max.y, _collider.bounds.min.z);
        corners[6].SetPosition(_collider.bounds.min.x, _collider.bounds.max.y, _collider.bounds.max.z);
        corners[7].SetPosition(_collider.bounds.max.x, _collider.bounds.max.y, _collider.bounds.max.z);
        //上面一层的ce
    }

    public coord GetCoord()
    {
        return _coord;
    }

    public void SetEnable()
    {
        this.isEnabled = true;
        this._collider.enabled = true;
        this._renderer.enabled = true;
        foreach (cornerElement ce in corners)
        {
            ce.SetCornerElement();
        }
    }

    public void SetDisable()
    {
        this.isEnabled = false;
        this._collider.enabled = false;
        this._renderer.enabled = false;
        foreach (cornerElement ce in corners)
        {
            ce.SetCornerElement();
        }
    }

    public bool GetEnabled()
    {
        return isEnabled;
    }
}
