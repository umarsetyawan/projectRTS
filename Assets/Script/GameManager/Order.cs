using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{

    public int Layer;
    public Vector3 Location;

    public enum OrderType { Idle, Mining, Building, Moving, Attacking };
    public OrderType TheOrder;

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

    public OrderType SetOrder()
    {
        GameManager.Instance.GetLayerandMousePosition();
        Layer = GameManager.Instance.Layer;
        Location = GameManager.Instance.MousePosition;
        if (Layer == 10)
        {
            TheOrder = OrderType.Mining;
        }
        if (Layer == 7)
        {
            TheOrder = OrderType.Moving;
        }
        if (Layer == 8)
        {
            TheOrder = OrderType.Building;
        }
        return TheOrder;
    }

}
