using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{

    public GameObject prefab; // object to pool
    public int poolSize = 10; // number objects to pre instantiate

    private List<GameObject> pool = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        // try to find an inactive object
        for (int i = 0; i < pool.Count; i++)
        {

            if (!pool[i].activeInHierarchy) // if not active in hierarchy, then they are available in pool
            {
                pool[i].SetActive(true); //sets active when called
                return pool[i]; //return object to calling class
            }
        }

        //if we got here then all objects active, then we must reset pool

        for (int i = 0; i < poolSize; i++)
        {
            pool[i].SetActive(false);
        }

        // hand out the first object after reset
        var obj = pool[0];
        obj.SetActive(true);
        return obj;
    }

}
