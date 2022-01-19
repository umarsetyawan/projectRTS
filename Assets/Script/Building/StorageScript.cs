using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageScript : MonoBehaviour
{
    private Storage storage;

    private void Awake()
    {
        storage = FindObjectOfType<Storage>();
        storage.Storages.Add(this.gameObject);
    }

}
