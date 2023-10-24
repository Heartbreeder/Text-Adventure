using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectionLogic : MonoBehaviour
{
    Text101Logic Logic;
    int selectionIndex;
    public void Init(Text101Logic logic, string desc, int selection)
    {
        Logic = logic;
        selectionIndex = selection;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = desc;
        GetComponent<Button>().onClick.AddListener(delegate { logic.ClickSelection(selectionIndex); });
        Debug.Log(selectionIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
