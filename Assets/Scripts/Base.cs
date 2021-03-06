using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(ClickHandler))]
[RequireComponent(typeof(DragHandler))]
public class Base : MonoBehaviour
{

    [Header("베이스의 소유자")]
    [SerializeField] BaseOwner _owner = BaseOwner.None;

    [Header("연결된 베이스")]
    [SerializeField] List<Base> _connectedBases;
    [SerializeField] List<Base> _roads;

    public int BaseID = 0;
    public bool IsSelected => _isSelected;
    public BaseOwner Owner
    {
        get => _owner;
        set
        {
            _owner = value;

            _baseColor = BaseManager.Instance.BaseDefaultColor;

            if (_owner == BaseOwner.Player)
            {
                _baseColor = Color.blue;
            }
            else if (_owner == BaseOwner.Enemy)
            {
                _baseColor = Color.red;
            }
            _spriteRenderer.color = _baseColor;

            GameWin();
        }

    }
    public List<Base> ConnectedBases => _connectedBases;

    private List<LineRenderer> lineRenderers = new List<LineRenderer>();
    private List<Base> _tempRoads = new List<Base>();

    public void SummonUnit(int unitID)
    {
        UnitCreateManager.Instance.UnitCreate(unitID, transform.position, _roads.Select(road => road.transform.position).ToList());
    }

    public void SetSelected(bool value)
    {
        _isSelected = value;

        if (value)
        {
            Color color = _baseColor;
            color -= new Color(0.5f, 0.5f, 0.5f, 0);
            _spriteRenderer.color = color;
            SelectEffector.Instance.Effect(this.transform.position);
            if (Owner == BaseOwner.Player)
            {
                _dragHandler.IsDraggable = true;
                lineRenderers.ForEach(line => line.gameObject.SetActive(true));
            }
        }
        else
        {
            _dragHandler.IsDraggable = false;
            _spriteRenderer.color = _baseColor;
            lineRenderers.ForEach(line => line.gameObject.SetActive(false));
        }
    }

    private int enemyBaseCount = 0;
    public void GameWin()
    {
        foreach (var EnemyBaseItem in BaseManager.Instance.BaseList)
        {
            if (EnemyBaseItem.Owner == BaseOwner.Enemy)
            {
                enemyBaseCount++;
            }
        }

        if (enemyBaseCount == 0)
        {
            Debug.Log("게임 승리");
        }
    }

    private ClickHandler clickHandler;
    private DragHandler _dragHandler;
    private SpriteRenderer _spriteRenderer;
    private Color _baseColor = Color.white;
    private bool _isSelected = false;

    void Start()
    {
        clickHandler = GetComponent<ClickHandler>();
        clickHandler.OnClick.AddListener(OnClick);

        _dragHandler = GetComponent<DragHandler>();
        _dragHandler.OnDragStart.AddListener(OnDragStart);
        _dragHandler.OnDrag.AddListener(OnDrag);
        _dragHandler.OnDragEnd.AddListener(OnDragEnd);

        _spriteRenderer = GetComponent<SpriteRenderer>();

        _baseColor = BaseManager.Instance.BaseDefaultColor;

        if (Owner == BaseOwner.Player)
        {
            _baseColor = Color.blue;
        }
        else if (Owner == BaseOwner.Enemy)
        {
            _baseColor = Color.red;
        }
        _spriteRenderer.color = _baseColor;
    }

    private void OnClick()
    {
        if(Owner == BaseOwner.None)
        {
            Debug.Log("현재 상태 : 미점령");
        }
        else if(Owner == BaseOwner.Player)
        {
            BaseManager.Instance.SelectBase(BaseID);
            Debug.Log("현재 상태 : 아군의 점령지");
        }
        else if (Owner == BaseOwner.Enemy)
        {
            Debug.Log("현재 상태 : 적군의 점령지");
        }
    }

    private void OnDragStart(Vector2 position)
    {
        Debug.Log("OnDragStart");

        _tempRoads.Clear();
        _tempRoads.Add(this);
        foreach (var lineRenderer in lineRenderers)
        {
            Destroy(lineRenderer.gameObject);
        }
        lineRenderers.Clear();

        lineRenderers.Add(CreateLineRenderer(transform.position, transform.position));
    }

    private LineRenderer CreateLineRenderer(Vector2 position1, Vector2 position2)
    {
        var lineRenderer = new GameObject("LineRenderer").AddComponent<LineRenderer>();
        lineRenderer.transform.parent = transform;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.positionCount = 2;
        lineRenderer.numCapVertices = 90;
        lineRenderer.SetPosition(0, position1);
        lineRenderer.SetPosition(1, position2);
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material.color = new Color(0, 0, 0, 0.5f);
        return lineRenderer;
    }

    private void OnDrag(Vector2 position)
    {
        for (int i = 0; i < _tempRoads[_tempRoads.Count - 1].ConnectedBases.Count; i++)
        {
            var b = _tempRoads[_tempRoads.Count - 1].ConnectedBases[i];
            if (_tempRoads.Contains(b)) continue;

            if (Vector2.Distance(b.transform.position, position) < 1.0f)
            {
                _tempRoads.Add(b);

                lineRenderers[lineRenderers.Count - 1].SetPosition(1, b.transform.position);
                lineRenderers.Add(CreateLineRenderer(lineRenderers[_tempRoads.Count - 2].GetPosition(1), b.transform.position));
            }
        }

        lineRenderers[_tempRoads.Count - 1].SetPosition(1, position);
    }

    private void OnDrawGizmosSelected()
    {
        foreach (var connectedBase in _connectedBases)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, connectedBase.transform.position);
        }
    }

    private void OnDragEnd(Vector2 position)
    {
        Debug.Log("OnDragEnd");
        Destroy(lineRenderers[lineRenderers.Count - 1].gameObject);
        lineRenderers.RemoveAt(lineRenderers.Count - 1);
        foreach (var line in lineRenderers)
        {
            line.material.DOColor(new Color(1, 1, 1, 0.5f), 0.5f);
        }
        _roads = _tempRoads;
    }
}
