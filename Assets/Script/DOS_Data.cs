using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOS_Data : MonoBehaviour
{
    public Tiga_array_bola viewer;
    // Start is called before the first frame update
    void Start()
    {
        testing();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void testing(){
        Check_daily_request_by_month data = get_data_by_month(3,2022);
        viewer.change_Data(data.total_baris, data.waktu, data.total_request,"total_request",data.total_object,"total_object",data.total_client,"total_client");
        viewer.visualize();

    }
    public Check_daily_request_by_month get_data_by_month(int month, int year){
        string route = "check_daily_request_by_month?year=" + year + "&month=" + month;
        string request = API_Connector.connect(route);
        Check_daily_request_by_month data = JsonUtility.FromJson<Check_daily_request_by_month>(request);
        return data;
    }
    public Check_request_on_day get_data_by_day(int day,int month,int year){
        string route = "check_request_on_day?year=" + year + "&month=" + month + "&day=" + day;
        string request = API_Connector.connect(route);
        Check_request_on_day data = JsonUtility.FromJson<Check_request_on_day>(request);
        return data;
    }
    public Check_daily_request get_data(){
        string route = "check_daily_request";
        string request = API_Connector.connect(route);
        Check_daily_request data = JsonUtility.FromJson<Check_daily_request>(request);
        return data;
    }    

}
