using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Date_Selector_WO_Day : MonoBehaviour
{
    public Dropdown drop_bulan,drop_tahun;
    public Button enter;
    Date_Range range;
    public System.DateTime selected_date;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(get_date_range());
    }
    void set_up(){
        set_tahun();
        drop_tahun.onValueChanged.AddListener(delegate {on_data_changed();});
        drop_bulan.onValueChanged.AddListener(delegate {on_data_changed();});
    }
    void set_tahun(){
        drop_tahun.ClearOptions();
        List<string> tahun = new List<string>();
        for(int i = range.startdate.Year; i <= range.enddate.Year; i++){
            tahun.Add(i.ToString());
        }
        drop_tahun.AddOptions(tahun);
    }
    void on_data_changed(){
        selected_date = new System.DateTime(int.Parse(drop_tahun.options[drop_tahun.value].text),1 + drop_bulan.value,1);
        Debug.Log("date changed: " + selected_date.ToString());
    }
    public class Date_Range{
        public string start;
        public string end;
        public System.DateTime startdate, enddate;
        public void compileRange(){
            startdate = System.DateTime.Parse(start);
            enddate = System.DateTime.Parse(end);
        }
 
    }
    IEnumerator get_date_range(){
        string route = "get_date_range";
        string url = API_Connector.host + route;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if(www.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            string request = www.downloadHandler.text;
            Date_Range data = JsonUtility.FromJson<Date_Range>(request);
            //do something here
            this.range = data;
            this.range.compileRange();
            set_up();
        }
    }

}
