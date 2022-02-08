using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowData : MonoBehaviour
{
    public Text text;
    private void Update()
    {
        text.text = "Gold : " + GameManager.Instance.gold;
    }

}
