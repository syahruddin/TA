using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiga_array_bola : MonoBehaviour
{
    public GameObject biru,merah,hijau;
    public GameObject [] view1;
    public GameObject [] view2;
    public GameObject [] view3;
    int max_height = 30;
    int length;
    string[] label;
    long[] data1;
    long[] data2;
    long[] data3;
    string data1_name;
    string data2_name;
    string data3_name;
    long max_data1;
    long max_data2;
    long max_data3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_Data(int length, string[] label, long[] data1, string data1_name, long[] data2, string data2_name, long[] data3, string data3_name)
    {
        this.length = length;
        this.label = label;
        this.data1 = data1;
        this.data2 = data2;
        this.data3 = data3;
        this.data1_name = data1_name;
        this.data2_name = data2_name;
        this.data3_name = data3_name;
        max_data1 = get_max(data1,length);
        max_data2 = get_max(data2,length);
        max_data3 = get_max(data3,length);
    }
    long get_max(long[] data, int length){
        long temp = 0;
        for(int i = 1; i <= length; i++){
            if(data[i-1] > temp) temp = data[i-1];
        }
        return temp;
    }
    public void visualize(){
        view1 = new GameObject[length];
        view2 = new GameObject[length];
        view3 = new GameObject[length];
        visualize_data(view1,data1,0,max_data1,biru);
        visualize_data(view2,data2,1,max_data2,merah);
        visualize_data(view3,data3,2,max_data3,hijau);
    }
    void visualize_data(GameObject[] view,long[] data, int z_location,long max,GameObject bola){
        for(int i = 1; i <= length; i++){
            float height = (max_height * data[i-1]) / max;
            view[i-1] = Instantiate(bola, new Vector3(i,height,z_location),Quaternion.identity);
            view[i-1].name = data[i-1].ToString();
        }
    }

}

