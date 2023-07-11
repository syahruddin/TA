using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bola : MonoBehaviour
{
    public Tiga_array_bola body;
    int index, data_index;
    long value;

    public void insert_Data(long value, int index, int data_index,Tiga_array_bola body){
        this.value = value;
        this.index = index;
        this.data_index = data_index;
        this.body = body;
        GameObject label = new GameObject("label");
        label.transform.parent = this.transform;
        label.transform.localPosition = this.transform.position + new Vector3(0,1,1);
        label.transform.rotation = Quaternion.Euler(0, -90, 0);
        label.transform.localScale = this.transform.localScale;
        TextMeshPro label_text = label.AddComponent<TextMeshPro>();
        label_text.SetText(value.ToString());
        label_text.fontSize = 10;
        label_text.alignment = TextAlignmentOptions.Center;
        label_text.color = Color.black;
    }

    void OnMouseOver(){
        
        if(Input.GetMouseButtonDown(0)){
            Debug.Log(value);
            body.ball_clicked(index,data_index);
        }
    }
}
