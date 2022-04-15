using System;
using UnityEngine;

public abstract class PoolableBehaviour<T> : MonoBehaviour where T : PoolableBehaviour<T>
{
    public Action<T> OnPool;
    public Action<T> OnUnpool;
    private Pool<T> pool;
    public Pool<T> Pool
    {
        set
        {
            if (pool != null)
                throw new Exception("Pool already set");
                
            pool = value;
        }
    }

    public void Destroy()
    {
        if (pool != null)
            pool.Put(this as T);
        else
            Destroy(gameObject);
    }
}