using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    public Text myText;
    public Text textHighest;
    // Start is called before the first frame update
    void Start()
    {
        string[] stats = GetComponent<StatisticsWriting>().Stats();
        myText.text = stats[0];
        textHighest.text = stats[1];
    }

}
