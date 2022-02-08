using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region public variable

    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> Storages = new List<GameObject>();

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
}
