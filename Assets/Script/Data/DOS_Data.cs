using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DOS_Data : MonoBehaviour
{
    public Tiga_array_bola viewer;
    public Date_Selector_WO_Day date;
    // Start is called before the first frame update
    void Start()
    {
        date.enter.onClick.AddListener(delegate {on_date_changed();});
        viewer.data_play = this;
        viewer.data_type = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(API_Connector.connect(""));
        }
    }
    void on_date_changed(){
        StartCoroutine(get_data_by_month(date.selected_date.Month,date.selected_date.Year));
    }
    public void ball_clicked(int day){
        StartCoroutine(get_data_by_day(day,date.selected_date.Month,date.selected_date.Year));
    }
    IEnumerator get_data_by_month(int month, int year){
        string route = "check_daily_request_by_month?year=" + year + "&month=" + month;
        string url = API_Connector.host + route;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if(www.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            string request = www.downloadHandler.text;
            Check_daily_request_by_month data = JsonUtility.FromJson<Check_daily_request_by_month>(request);
            viewer.change_Data(data.total_baris, data.waktu,data.total_client,"total_client", data.total_request,"total_request",data.total_object,"total_object");
            viewer.set_date(month,year);
        }
    }
    IEnumerator get_data_by_day(int day,int month,int year){
        string route = "check_request_on_day?year=" + year + "&month=" + month + "&day=" + day;
        string url = API_Connector.host + route;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if(www.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            string request = www.downloadHandler.text;
            Check_request_on_day data = JsonUtility.FromJson<Check_request_on_day>(request);
            viewer.change_Data(data.total_baris, data.ip_address, data.total_request,"total_request",data.total_object,"total_object");
            viewer.set_date(day,month,year);
        }
    }
    public Check_daily_request get_data(){
        string route = "check_daily_request";
        string request = API_Connector.connect(route);
        Check_daily_request data = JsonUtility.FromJson<Check_daily_request>(request);
        return data;
    }    
}
