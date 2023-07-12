using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Scanning_data : MonoBehaviour
{
    public Tiga_array_bola viewer;
    public Dropdown option;
    public Date_Selector_WO_Day date;
    public string keyword;
    // Start is called before the first frame update
    void Start()
    {
        date.enter.onClick.AddListener(delegate {on_date_changed();});
        option.onValueChanged.AddListener(delegate {on_date_changed();});
        viewer.data_scan = this;
        viewer.data_type =2;
        viewer.level = 0;
    }
    void on_date_changed(){
        keyword = (option.value + 1).ToString();
        StartCoroutine(get_status_code_on_month(date.selected_date.Month,date.selected_date.Year,keyword));
    }
    public void ball_clicked(int day){
        StartCoroutine(get_status_code_per_ip(day,date.selected_date.Month,date.selected_date.Year,keyword));
    }

    IEnumerator get_status_code_on_month(int month,int year, string keyword){
        string route = "check_status_code_occurence_on_month?year=" + year + "&month=" + month + "&keyword=" + keyword;
        string url = API_Connector.host + route;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if(www.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            string request = www.downloadHandler.text;
            viewer.level = 1;
            Check_status_code_occurence_on_month data = JsonUtility.FromJson<Check_status_code_occurence_on_month>(request);
            viewer.change_Data(data.total_baris, data.waktu,data.total_status,"total_status");
            viewer.set_date(month,year);
        }
    }
    IEnumerator get_status_code_per_ip(int day,int month,int year, string keyword){
        string route = "check_status_code_occurence_per_ip?year=" + year + "&month=" + month + "&day=" + day + "&keyword=" + keyword;
        string url = API_Connector.host + route;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if(www.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            string request = www.downloadHandler.text;
            Check_status_code_occurence_per_ip data = JsonUtility.FromJson<Check_status_code_occurence_per_ip>(request);
            //do something here
            viewer.change_Data(data.total_baris, data.ip_address,data.total_status,"total_status");
            viewer.set_date(day,month,year);
            viewer.level = 2;
        }
    }

}
