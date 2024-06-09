using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinCollector : MonoBehaviour
{
    public GameObject coin_display;
    public static int count=0;
    void FixedUpdate()
    {
        coin_display.GetComponent<TextMeshProUGUI>().text= "" + count;
    }
}
