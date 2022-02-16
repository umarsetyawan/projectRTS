using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    [SerializeField] private LayerMask _Ground;
    #region public variable

    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> Buildings = new List<GameObject>();
    public List<GameObject> BuildingUnderConstruction = new List<GameObject>();
    public LayerMask Layer;
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
    public Vector3 GroundMouseLocation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity, _Ground);
        return hit.point;
    }

    public void GetLayerandMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        Layer = hit.transform.gameObject.layer;
        MousePosition = hit.point;
    }

}
