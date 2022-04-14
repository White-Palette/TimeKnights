using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStorage : MonoSingleton<BaseStorage>
{
    private List<Base> _baseList = new List<Base>();
    public uint _playerBaseCount { get; private set; } = 0;
    public uint _enemyBaseCount { get; private set; } = 0;

    void Start()
    {
        
    }

    public void SetBaseCount()
    {
        _playerBaseCount = 0;
        _enemyBaseCount = 0;
        for (int i = 0; i < _baseList.Count; i++)
        {
            if (_baseList[i].Owner == BaseOwner.Player)
            {
                _playerBaseCount++;
            }
            else if (_baseList[i].Owner == BaseOwner.Enemy)
            {
                _enemyBaseCount++;
            }
        }
    }

}
