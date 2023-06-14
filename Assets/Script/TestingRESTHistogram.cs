using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System.Reflection;

public class TestingRESTHistogram : MonoBehaviour
{
    public Histogram_view viewer;

    void Start()
    {
        string dataJson = requestAPI();
        UsagePerDay data = JsonUtility.FromJson<UsagePerDay>(dataJson);
        Histogram_Data histogram = new Histogram_Data(data.total_baris,data.jumlah_hari);
        for(int i = 1; i <= data.total_baris; i++){
            for(int j = 1; j <= data.jumlah_hari; j++){
                histogram.change_data(i,j,data.get_day(j)[i-1]);
            }
        }

        viewer.change_data(histogram);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    string requestAPI(){
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:5000/test");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        return reader.ReadToEnd();
    }

    public class UsagePerDay{
        public int bulan;
        public int tahun;
        public int jumlah_hari;
        public int total_baris;
        public string[] ip_address;
        public int[] day_1,day_2,day_3,day_4,day_5,day_6,day_7,day_8,day_9,day_10,day_11,day_12,day_13,day_14,day_15,day_16,day_17,day_18,day_19,day_20,day_21,day_22,day_23,day_24,day_25,day_26,day_27,day_28,day_29,day_30,day_31;

        public int[] get_day(int day){
            //if(day > jumlah_hari) return 0;
            string var_name = "day_" + day;
            return (int[])this.GetType().GetField(var_name).GetValue(this);

            
        }
        

    }
}
