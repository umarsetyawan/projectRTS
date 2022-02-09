using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBuilding : MonoBehaviour
{
    [SerializeField] private BuildingsSO building;
    public void build()
    {
        Camera.main.GetComponent<DragSelect>().enabled = false;
        Instantiate(building.Prefab, transform.position, transform.rotation);

    }
}
