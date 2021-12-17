using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

    private static Selection _instance;

    public static Selection Instance { get { return _instance; } }

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


    public void clickSelect(GameObject unitToSelect)
    {
        unitToSelect.GetComponent<UnitMovementScript>().enabled = false;
        deselectAll();
        unitSelected.Add(unitToSelect);
        unitToSelect.GetComponent<UnitMovementScript>().enabled = true;
        
    }

    public void shiftClickSelect(GameObject unitToSelect)
    {
        if (!unitSelected.Contains(unitToSelect))
        {
            unitSelected.Add(unitToSelect);
            unitToSelect.GetComponent<UnitMovementScript>().enabled = true;
        }
        else
        {
            unitToSelect.GetComponent<UnitMovementScript>().enabled = false;
            unitSelected.Remove(unitToSelect);
        }
    }

    public void dragSelect(GameObject unitToSelect)
    {
        if (!unitSelected.Contains(unitToSelect))
        {
            unitSelected.Add(unitToSelect);
            unitToSelect.GetComponent<UnitMovementScript>().enabled = true;
        }
    }


    public void deselectAll()
    {
        foreach (var unit in unitSelected)
        {
            unit.GetComponent<UnitMovementScript>().enabled = false;
        }
        
        unitSelected.Clear();
    }

}
