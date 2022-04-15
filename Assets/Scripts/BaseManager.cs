using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BaseManager : MonoSingleton<BaseManager>
{
    public uint PlayerBaseCount { get; private set; } = 0;
    public uint EnemyBaseCount { get; private set; } = 0;
    public int SelectedBase => _selectedBase;

    private List<Base> _baseList = new List<Base>();
    public Color BaseDefaultColor => _baseDefaultColor;

    [SerializeField]
    private Color _baseDefaultColor = Color.white;
    private int _selectedBase = -1;

    private void Start()
    {
        _baseList.AddRange(FindObjectsOfType<Base>());
        _baseList.ForEach(baseObj => baseObj.BaseID = _baseList.IndexOf(baseObj));
    }

    public void SelectBase(int baseID)
    {
        _selectedBase = baseID;

        _baseList.ForEach(baseObj => baseObj.SetSelected(baseObj.BaseID == baseID));
    }

    public void SummonUnit(int unitID)
    {
        if (_selectedBase == -1)
            return;
        _baseList[_selectedBase].SummonUnit(unitID);
    }
}
