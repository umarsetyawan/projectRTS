using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBuilding : MonoBehaviour
{
   public void Build(Vector3 location, Quaternion rotation)
    {
        Instantiate(this.gameObject, location, rotation);
    }
}
