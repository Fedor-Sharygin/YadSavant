using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabResults : MonoBehaviour
{
    private void Awake()
    {
        var ResultsText = new string[3];
        ResultsText[0] = $"You have satisfied {DayManager.SuccessfullResults} out of {DayManager.TotalResults} customers.";
        ResultsText[1] = "The assassin's guild no longer requires your assistance.";
        ResultsText[2] = "Farewell";
        GetComponent<TextPresenter>()?.SetTextArray(ResultsText);
    }
}
