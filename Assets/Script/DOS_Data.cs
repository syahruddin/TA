using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOS_Data : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Check_daily_request_by_month get_data_by_month(int month, int year){
        string route = "check_daily_request_by_month?year=" + year + "month=" + month;
        string request = API_Connector.connect(route);
        Check_daily_request_by_month data = JsonUtility.FromJson<Check_daily_request_by_month>(request);
        return data;
    }
    public Check_request_on_day get_data_by_day(int day,int month,int year){
        string route = "check_request_on_day?year=" + year + "month=" + month + "day=" + day;
        string request = API_Connector.connect(route);
        Check_request_on_day data = JsonUtility.FromJson<Check_request_on_day>(request);
        return data;
    }

}
