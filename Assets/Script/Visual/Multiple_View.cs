using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Multiple_View : MonoBehaviour
{
    List<GameObject> view = new List<GameObject>();
    public Dropdown ui_dropdown;
    public Button ui_button;
    // Start is called before the first frame update
    void Start()
    {
        ui_button.onClick.AddListener(delegate {add_view();});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void add_view(){

    }
    void remove_view(){

    }
}
