using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date_Selector : MonoBehaviour
{
    Date_Range range;
    // Start is called before the first frame update
    void Start()
    {
        get_date_range();
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
    class Date_Range{
        public string start;
        public string end;
        Waktu startdate, enddate;
        public void compileRange(){
            startdate = new Waktu(start);
            enddate = new Waktu(end);
        }

    }
}
