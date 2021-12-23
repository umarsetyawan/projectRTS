using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    private Selection selection;

    private bool isSelected;

    private void Awake()
    {
        selection = FindObjectOfType<Selection>();
        selection.unitList.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        selection.unitList.Remove(this.gameObject);
    }

    public void click()
    {
        if (isSelected)
        {
            isSelected = false;
        }
        else
        {
            isSelected = true;
        }
    }

    private void Update()
    {

    }

}
