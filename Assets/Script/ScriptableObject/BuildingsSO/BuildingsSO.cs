using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingsSO : ScriptableObject
{
    public string Name;

    [Header("Config")]
    public int Health;
    public float BuiltTime;
    public GameObject Prefab;


}
