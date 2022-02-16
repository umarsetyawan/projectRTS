using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private int closestIndex;
    private float minDist;
    private float dist;

    private static Storage _instance;

    public static Storage Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        minDist = Mathf.Infinity;
    }


    public GameObject GetClosestStorage(Vector3 unitLocation)
    {
        for (int i = 0; i < GameManager.Instance.Buildings.Count; i++)
        {
            if (dist < minDist)
            {
                closestIndex = i;
                minDist = dist;
            }
        }
        return closestIndex == -1 ? null : GameManager.Instance.Buildings[closestIndex];
        
    }


}
