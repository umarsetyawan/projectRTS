using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour, ISelectable
{
    protected bool _isSelected;
    public bool IsFinnished = false;

    
    public void Select()
    {
        _isSelected = true;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    public void Deselect()
    {
        _isSelected = false;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }

    public virtual void OnBuild()
    {

    }

    public virtual void OnFinnished()
    {

    }

}
