using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cornerMeshes : MonoBehaviour
{
    public static cornerMeshes instance;
    public GameObject mesh;
    private Dictionary<int, Mesh> meshes = new Dictionary<int, Mesh>();
    
    void Awake()
    {
        instance = this;
        instance.Initialize();
        
        /*foreach(KeyValuePair<string,Mesh> item in meshes)
        {
            Debug.Log("Key: " + item.Key);
            Debug.Log("Value: " + item.Value.name);
        }*/
        //字典没问题
    }

    private void Initialize()
    {
        foreach (Transform child in mesh.transform)
        {
            meshes.Add(int.Parse(child.name), child.GetComponent<MeshFilter>().sharedMesh);
        }
        
    }

    public Mesh GetCornerMesh(int bitmask)
    {
        Mesh result = null;

        if (meshes.TryGetValue(bitmask, out result))
        {
            //Debug.Log(result.name);
            return result;
        }
        return null;
    }
    
}
