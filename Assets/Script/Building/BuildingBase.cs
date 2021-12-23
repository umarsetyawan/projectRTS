using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase : MonoBehaviour
{

    [Header("Info")]
    [SerializeField] private string Name;
    [SerializeField] private string Description;
    [SerializeField] private float Health;

    [Header("Config")]
    [SerializeField] private float BuiltTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onBuilding()
    {

    }

}
