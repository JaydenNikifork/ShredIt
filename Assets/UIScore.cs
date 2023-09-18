using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text score = GetComponent<TMP_Text>();
        score.text = PlayNote.score.ToString();
    }
}
