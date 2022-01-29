using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        string[] stats = GetComponent<StatisticsWriting>().Stats();
        myText.text = stats[0];
    }

}
