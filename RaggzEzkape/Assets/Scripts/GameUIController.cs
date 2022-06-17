using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [Header("UI")]
    public Text userNameOutput;
    public Text scoreOutput;
    // Start is called before the first frame update
    void Start()
    {
        userNameOutput.text = GlobalVariables.Playername!=null?GlobalVariables.Playername.ToUpper():"Guest";
        scoreOutput.text = "Score: "+GlobalVariables.Distance.ToString();
    }
    void OnEnable() {
        userNameOutput.text = GlobalVariables.Playername!=null?GlobalVariables.Playername.ToUpper():"Guest";
        scoreOutput.text = "Score: "+GlobalVariables.Distance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreOutput.text = "Score: "+GlobalVariables.Distance.ToString();
    }
}
