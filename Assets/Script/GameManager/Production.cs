using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour
{


    private static Production _instance;

    public static Production Instance { get { return _instance; } }
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
