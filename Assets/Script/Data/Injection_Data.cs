using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Injection_Data : MonoBehaviour
{
    public InputField input;
    public Tiga_array_bola viewer;
    public Date_Selector_WO_Day date;
    public string keyword = "";
    // Start is called before the first frame update
    void Start()
    {
        date.enter.onClick.AddListener(delegate {on_date_changed();});
        viewer.data_inject = this;
        viewer.data_type = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void on_date_changed(){
        keyword = input.text;
        StartCoroutine(get_keyword(date.selected_date.Month,date.selected_date.Year,keyword));
    }

    IEnumerator get_keyword(int month,int year, string keyword){
        string route = "search_usage_of_keyword_on_month?year=" + year + "&month=" + month + "&keyword=" + keyword;
        string url = API_Connector.host + route;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if(www.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            string request = www.downloadHandler.text;
            Search_usage_of_keyword_on_month data = JsonUtility.FromJson<Search_usage_of_keyword_on_month>(request);
            //do something here
            viewer.change_Data(data.total_baris, data.ip_address,data.total_request,"total_request");
            viewer.set_date(month,year);
        }
    }
}
