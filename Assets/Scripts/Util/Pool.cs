using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pool<T> where T : PoolableBehaviour<T>
{
    private readonly Stack<T> _pool = new Stack<T>();
    private readonly HashSet<GameObject> _pooledObjects = new HashSet<GameObject>();
    private readonly GameObject _prefab;
    private readonly Transform _parent;

    public Pool(GameObject prefab, Action<T> onPool, int preGenerate = 0, Transform parent = null)
    {
        if (parent == null)
            parent = new GameObject(typeof(T).ToString()).transform;

        _prefab = prefab;
        _parent = parent;

        for (int i = 0; i < preGenerate; i++)
        {
            GameObject go = GameObject.Instantiate(prefab, parent);
            go.SetActive(false);
            T poolable = go.GetComponent<T>();
            poolable.OnPool += onPool;
            _pool.Push(poolable);
        }
    }

    public Pool(GameObject prefab, Transform parent = null) : this(prefab, null, 0, null)
    {
    }

    public T Get()
    {
        T item;
        if (_pool.Count > 0)
        {
            item = _pool.Pop();
            item.gameObject.SetActive(true);
        }
        else
        {
            var obj = GameObject.Instantiate(_prefab, _parent);
            obj.name = _prefab.name;
            item = obj.GetComponent<T>();
            if (item == null)
                throw new Exception("Pool item does not have a component of type " + typeof(T).ToString());
            item.Pool = this;
        }
        _pooledObjects.Add(item.gameObject);
        item.OnPool?.Invoke(item);
        return item;
    }

    public T Get(Action<T> onPool)
    {
        T item = Get();
        onPool.Invoke(item);
        return item;
    }

    public T Get(Vector3 position, Action<T> onPool)
    {
        T item = Get();
        item.transform.position = position;
        onPool.Invoke(item);
        return item;
    }

    public void Put(T obj)
    {
        if (!_pooledObjects.Contains(obj.gameObject))
            throw new Exception("Object is not in this pool");

        obj.OnUnpool?.Invoke(obj);
        obj.gameObject.SetActive(false);
        _pooledObjects.Remove(obj.gameObject);
        _pool.Push(obj);
    }
}