using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    public TextMeshPro display;


    private void Update()
    {
        display.text = "You have " + Globals.currentMoney + " Ahn.";
    }
}
