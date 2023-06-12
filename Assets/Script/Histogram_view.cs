using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Histogram_view : MonoBehaviour
{
    public GameObject box;
    public GameObject [,] view;
    int buffer = 2;

    Histogram_Data data;


    void Start()
    {
        //testing
        data = new_Testing_Data();
        
        update_view();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Histogram_Data new_Testing_Data(){
        Histogram_Data data = new Histogram_Data(3,3);
        for(int i = 1; i <= data.get_x(); i++){
            for(int j = 1; j <= data.get_y(); j++){
                data.change_data(i,j,(int)Random.Range(1,10));
            }
        }
        return data;
    }

    public void change_data(Histogram_Data data){
        this.data = data;
        update_view();
    }
    void update_view(){
        view = new GameObject[data.get_x(),data.get_y()];
        for(int i = 0; i < data.get_x(); i++){
            for(int j = 0; j < data.get_y(); j++){
                view[i,j] = Instantiate(box, new Vector3(i*buffer,0,j*buffer), Quaternion.identity);
                Debug.Log("spawn " + i + "," + j + "= " + data.get_value(i+1,j+1) );
                view[i,j].transform.localScale = new Vector3(1,5 * data.get_value(i+1,j+1) /data.get_highest_val(),1);
                view[i,j].transform.position += new Vector3(0,view[i,j].transform.localScale.y / 2,0);
            }
        }
    }
}
