using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundController : MonoBehaviour
{
    static public float roundCount = 0f;
    // Start is called before the first frame update
    void Start()
    {
        roundCount++;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = "Round: " + roundCount;
    }
}
