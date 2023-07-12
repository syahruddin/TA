using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Multiple_View : MonoBehaviour
{
    List<GameObject> view = new List<GameObject>();
    public Dropdown ui_dropdown;
    public Button ui_button;
    public GameObject prefabDOS,prefabInject,prefabScan;
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
        int option = ui_dropdown.value;
        GameObject new_view;
        switch(option){
            case 0:
                new_view = Instantiate(prefabDOS,this.transform.position + new Vector3(0,1,0),Quaternion.identity);
                view.Add(new_view);
                break;
            case 1:
                new_view = Instantiate(prefabInject,this.transform.position + new Vector3(0,1,0),Quaternion.identity);
                view.Add(new_view);
                break;
            case 2:
                new_view = Instantiate(prefabScan,this.transform.position + new Vector3(0,1,0),Quaternion.identity);
                view.Add(new_view);
                break;
            default:
                break;
        }
    }
    void remove_view(){

    }
    void remove_all_view(){
        foreach (GameObject tampilan in view)
        {
            Destroy(tampilan);
        }
    }
}
