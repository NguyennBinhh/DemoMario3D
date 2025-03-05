using System.Collections.Generic;
using UnityEngine;

public class ObjPooling : MonoBehaviour
{
    public GameObject Prefab;
    [SerializeField] private int PoolSize = 10;
    private Queue<GameObject> pool;

    private void Awake()
    {
        pool = new Queue<GameObject>();

        for (int i = 0; i < PoolSize; i++) 
        {  
 
            GameObject obj = Instantiate(Prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetBullet(Vector3 position, Quaternion rotation)
    {
        GameObject obj;

        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            obj = Instantiate(Prefab);
        }

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
        return obj;
    }

    public void ReturnBullet(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
