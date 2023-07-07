using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiga_array_bola : MonoBehaviour
{
    public DOS_Data data_play;
    public GameObject biru,merah,hijau;
    public GameObject [] view1;
    public GameObject [] view2;
    public GameObject [] view3;
    List<LineRenderer> garis = new List<LineRenderer>();
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
            view1 = new GameObject[length];
            view2 = new GameObject[length];
            if(number_of_data == 3) view3 = new GameObject[length];
            visualize_data(view1,data1,0,max_data1,1,biru);
            visualize_data(view2,data2,1,max_data2,2,merah);
            if(number_of_data == 3) visualize_data(view3,data3,2,max_data3,3,hijau);
            for(int i = 1; i <= length; i++){
                draw_line_between(view1[i-1], view2[i-1], Color.black);
                if(number_of_data == 3) draw_line_between(view2[i-1], view3[i-1], Color.black);
            }
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
        Debug.Log("All view destroyed");
    }
    void visualize_data(GameObject[] view,long[] data, int z_location,long max,int data_index,GameObject bola){
        for(int i = 1; i <= length; i++){
            float height = (max_height * data[i-1]) / max;
            view[i-1] = Instantiate(bola, new Vector3(i,height,z_location),Quaternion.identity);
            view[i-1].GetComponent<Bola>().insert_Data(data[i-1],i,data_index,this);
        }
    }
    void draw_line_between(GameObject object1, GameObject object2, Color color){
        Vector3 position1,position2;
        position1 = object1.transform.position;
        position2 = object2.transform.position;


        LineRenderer lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;    
        lineRenderer.SetPosition(0, position1);
        lineRenderer.SetPosition(1, position2);

        garis.Add(lineRenderer);
    }
    public void ball_clicked(int index, int data_index){
        if(number_of_data == 3){
            data_play.ball_clicked(index);
        }
    }

}

