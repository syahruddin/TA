using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tiga_array_bola : MonoBehaviour
{
    public Text label_merah,label_hijau,label_biru;
    public DOS_Data data_play;
    public GameObject selfrefer;
    public Request_line_perIP req_ui;
    public GameObject biru,merah,hijau;
    public GameObject [] view1;
    public GameObject [] view2;
    public GameObject [] view3;
    public GameObject ofset;
    int level = 0;
    int jarak = 2;
    float ofset_value;
    List<LineRenderer> garis = new List<LineRenderer>();
    List<GameObject> label_text = new List<GameObject>();
    int max_height = 30;
    int number_of_data = 0;
    int length = -1;
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
    int day,month,year;

    public void change_Data(int length, string[] label, long[] data1, string data1_name, long[] data2, string data2_name, long[] data3, string data3_name)
    {
        number_of_data = 3;
        bool isinit = (this.length < 0);
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
        Debug.Log("Data changed");
        if(!isinit){
            destroy_all();
        //    yield return new WaitForSeconds(1);
        }
        visualize();
    }
    public void change_Data(int length, string[] label, long[] data1, string data1_name, long[] data2, string data2_name)
    {
        number_of_data = 2;
        bool isinit = (this.length < 0);
        this.length = length;
        this.label = label;
        this.data1 = data1;
        this.data2 = data2;
        this.data1_name = data1_name;
        this.data2_name = data2_name;
        max_data1 = get_max(data1,length);
        max_data2 = get_max(data2,length);
        Debug.Log("Data changed");
        if(!isinit){
            destroy_all();
        //    yield return new WaitForSeconds(1);
        }
        visualize();
    }
    long get_max(long[] data, int length){
        long temp = 0;
        for(int i = 1; i <= length; i++){
            if(data[i-1] > temp) temp = data[i-1];
        }
        return temp;
    }
    public void visualize(){
        if(length > 0){
            reset_ofset();
            reset_label();
            view1 = new GameObject[length];
            view2 = new GameObject[length];
            if(number_of_data == 3) view3 = new GameObject[length];
            visualize_data(view1,data1,-4,max_data1,1,biru);
            label_biru.text = data1_name;
            visualize_data(view2,data2,0,max_data2,2,merah);
            label_merah.text = data2_name;
            if(number_of_data == 3) {
                visualize_data(view3,data3,4,max_data3,3,hijau);
                label_hijau.text = data3_name;
            }
            set_label();
            set_ofset();
            for(int i = 1; i <= length; i++){
                draw_line_between(view1[i-1], view2[i-1]);
                if(number_of_data == 3) draw_line_between(view2[i-1], view3[i-1]);
            }
            
        }
    }
    string get_data_name(int index){
        switch (index)
        {
            case 1:
                return data1_name;
            case 2:
                return data2_name;
            case 3:
                return data3_name;
            default:
                return "wrong_index";
        }
    }
    void destroy_all(){
        foreach(GameObject ball in view1){
            Destroy(ball);
        }
        foreach(GameObject ball in view2){
            Destroy(ball);
        }
        foreach(GameObject ball in view3){
            Destroy(ball);
        }
        foreach(LineRenderer line in garis){
            Destroy(line);
        }
        foreach(GameObject label in label_text){
            Destroy(label);
        }
        Debug.Log("All view destroyed");
    }
    void visualize_data(GameObject[] view,long[] data, int z_location,long max,int data_index,GameObject bola){
        for(int i = 1; i <= length; i++){
            float height = (max_height * data[i-1]) / max;
            view[i-1] = Instantiate(bola);
            view[i-1].GetComponent<Bola>().insert_Data(data[i-1],i,data_index,this);
            view[i-1].transform.parent = ofset.transform;
            view[i-1].transform.localPosition= new Vector3((i-1)*jarak,height,z_location);
            view[i-1].transform.rotation= Quaternion.identity;
            view[i-1].transform.localScale = view[i-1].transform.parent.transform.localScale;
        }
    }
    void draw_line_between(GameObject object1, GameObject object2){
        Vector3 position1,position2;
        position1 = object1.transform.position;
        position2 = object2.transform.position;

        Color color = stretch(position1,position2);


        LineRenderer line = new GameObject("Line").AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        line.startColor = color;
        line.useWorldSpace = false;
        line.endColor = color;
        line.startWidth = 0.2f * get_scale();
        line.endWidth = 0.2f * get_scale();
        line.positionCount = 2;
        line.useWorldSpace = false;    
        line.SetPosition(0, position1);
        line.SetPosition(1, position2);
        line.transform.parent = ofset.transform;
        garis.Add(line);
    }
    public void ball_clicked(int index, int data_index){
        if(number_of_data == 3){
            data_play.ball_clicked(index);
        }
        if(number_of_data == 2){
            req_ui.search_ip_address(day, month, year, label[index-1]);
        }
    }
    Color stretch(Vector3 a, Vector3 b){
        float height = Mathf.Abs(a.y - b.y);
        float height_rate = height/(max_height*get_scale());
        Color temp = new Color(height_rate,1-height_rate,0,1);
        return temp;
    }
    void set_ofset(){
        ofset_value = 0-(length*jarak * get_scale()/2);
        ofset.transform.position = new Vector3(ofset_value,ofset.transform.position.y,ofset.transform.position.z);
    }
    void reset_ofset(){
        ofset.transform.position = new Vector3(0,ofset.transform.position.y,ofset.transform.position.z);
    }
    public void set_date(int day, int month, int year){
        this.day = day;
        this.month = month;
        this.year = year;
    }
    public void set_date(int month, int year){
        this.day = 1;
        this.month = month;
        this.year = year;
    }
    float get_scale(){
        return selfrefer.transform.localScale.x;
    }
    void reset_label(){
        label_hijau.text="";
        label_biru.text="";
        label_merah.text="";

    }
    void set_label(){
        for(int i = 1; i <= length;i++){
            GameObject label = new GameObject(i.ToString());
            label.transform.parent = ofset.transform;
            label.transform.localPosition = new Vector3((i-1)*jarak,-1,-5);
            label.transform.rotation = Quaternion.Euler(0, -90, 0);
            label.transform.localScale = ofset.transform.localScale;
            TextMeshPro label_text = label.AddComponent<TextMeshPro>();
            label_text.SetText(this.label[i-1]);
            label_text.color = Color.black;
            label_text.fontSize = 10;
            label_text.alignment = TextAlignmentOptions.Center;

            this.label_text.Add(label);
        }
    }

}

