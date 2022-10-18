using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    public TextMeshProUGUI display;

    private void Update()
    {
        display.text = "You have " + Globals.currentMoney + " Ahn.";
    }
}
