using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Tiga_array_bola body;
    int index, data_index;
    long value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void insert_Data(long value, int index, int data_index,Tiga_array_bola body){
        this.value = value;
        this.index = index;
        this.data_index = data_index;
        this.body = body;
    }

    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            Debug.Log(value);
            body.ball_clicked(index,data_index);
        }
    }
}
