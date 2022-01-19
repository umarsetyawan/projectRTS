using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBuilding : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public void build()
    {
        Camera.main.GetComponent<DragSelect>().enabled = false;
        Instantiate(prefab, transform.position, transform.rotation);


    }
}
