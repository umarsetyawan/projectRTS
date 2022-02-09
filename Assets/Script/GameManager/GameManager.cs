using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    [SerializeField] private LayerMask _Ground;
    #region public variable

    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> Storages = new List<GameObject>();
    public Vector3 MousePosition;

    #region Resource
    public int gold;
    public int wood;
    #endregion

    #endregion

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Init()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        MousePosition = GetMousePos();
    }
    private Vector3 GetMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity, _Ground);
        return hit.point;
    }

}
