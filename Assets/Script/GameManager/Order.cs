using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{

    public int Layer;
    public Vector3 Location;


    private static Order _instance;

    public static Order Instance { get { return _instance; } }

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
    }

    public void GetLocationAndLayer()
    {
        if (Selection.Instance.unitSelected.Count > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            Layer = hit.transform.gameObject.layer;
            Location = hit.point;
        }
    }

}
