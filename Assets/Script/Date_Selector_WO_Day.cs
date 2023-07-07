using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date_Selector_WO_Day : MonoBehaviour
{
    public Dropdown drop_bulan,drop_tahun;
    public Button enter;
    Date_Range range;
    public System.DateTime selected_date;
    // Start is called before the first frame update
    void Start()
    {
        set_up();
    }

    void get_date_range(){
        string request = API_Connector.connect("get_date_range");
        Date_Range data = JsonUtility.FromJson<Date_Range>(request);
        this.range = data;
        this.range.compileRange();
    }
    void set_up(){
        get_date_range();
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

}
