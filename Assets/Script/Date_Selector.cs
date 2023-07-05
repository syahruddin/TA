using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date_Selector : MonoBehaviour
{
    public Dropdown drop_hari,drop_bulan,drop_tahun;
    Date_Range range;
    public System.DateTime selected_date;
    // Start is called before the first frame update
    void Start()
    {
        set_up();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        set_hari();
        drop_tahun.onValueChanged.AddListener(delegate {on_year_changed();});
        drop_bulan.onValueChanged.AddListener(delegate {on_month_changed();});
        drop_hari.onValueChanged.AddListener(delegate {on_day_changed();});
    }
    void set_tahun(){
        drop_tahun.ClearOptions();
        List<string> tahun = new List<string>();
        for(int i = range.startdate.Year; i <= range.enddate.Year; i++){
            tahun.Add(i.ToString());
        }
        drop_tahun.AddOptions(tahun);
    }
    void set_hari(){
        drop_hari.ClearOptions();
        int bulan = 1 + drop_bulan.value;
        int tahun = int.Parse(drop_tahun.options[drop_tahun.value].text);
        int last_Day = System.DateTime.DaysInMonth(tahun,bulan);
        List<string> hari = new List<string>();
        for(int i = 1; i <= last_Day; i++){
            hari.Add(i.ToString());
        }
        drop_hari.AddOptions(hari);
    }
    void on_year_changed(){
        set_hari();
        on_data_changed();
    }
    void on_month_changed(){
        set_hari();
        on_data_changed();
    }
    void on_day_changed(){

        on_data_changed();
    }
    void on_data_changed(){
        selected_date = new System.DateTime(int.Parse(drop_tahun.options[drop_tahun.value].text),1 + drop_bulan.value,1 + drop_hari.value);
    }
    class Date_Range{
        public string start;
        public string end;
        public System.DateTime startdate, enddate;
        public void compileRange(){
            startdate = System.DateTime.Parse(start);
            enddate = System.DateTime.Parse(end);
        }

    }

}
