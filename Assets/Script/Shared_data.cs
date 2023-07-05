using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shared_data
{
    public static Get_request_line_and_status_code get_request_by_ip(int day, int month, int year, string ip){
        string route = "get_request_line_and_status_code?year=" + year + "month=" + month + "day=" + day + "ip_address=" + ip;
        string request = API_Connector.connect(route);
        Get_request_line_and_status_code data = JsonUtility.FromJson<Get_request_line_and_status_code>(request);
        return data;
    }
    
}
public class Waktu{
    public int tahun,bulan,hari;
    public string waktu;
    public Waktu(string waktu){
    }
    public Waktu(int tahun,int bulan,int hari){
        this.tahun = tahun;
        this.bulan = bulan;
        this.hari = hari;
    }
    public bool isSameDay(Waktu patokan){
        return ((patokan.tahun == this.tahun) && (patokan.bulan == this.bulan) && (patokan.hari == this.hari));
    }
}
