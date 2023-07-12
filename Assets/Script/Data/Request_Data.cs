public class Request_Data
{
   public int total_baris;

}

public class Month_Data : Request_Data
{
    public int bulan;
    public int tahun;
}

public class Day_data : Month_Data
{
    public int hari;
}

public class Check_daily_request : Request_Data{
    public string[] waktu;
    public long[] total_request,total_object,total_client;

}
public class Check_daily_request_by_month : Month_Data{
    public string[] waktu;
    public long[] total_request,total_object,total_client;
}
public class Check_request_on_day : Day_data{
    public string[] ip_address;
    public long[] total_request,total_object;
}
public class Get_request_line_and_status_code : Day_data{
    public int timeless;
    public string keyword;
    public string ip_address;
    public string[] waktu;
    public string[] request_line;
    public int[] status_code;
}
public class Search_usage_of_keyword : Request_Data{
    public string keyword;
    public string[] ip_address;
    public long[] total_request;
}
public class Search_usage_of_keyword_on_month : Month_Data{
    public string keyword;
    public string[] ip_address;
    public long[] total_request;
}
public class Check_status_code_occurence : Request_Data{
    public string keyword;
    public string[] waktu;
    public long[] total_status;
}
public class Check_status_code_occurence_on_month : Month_Data{
    public string keyword;
    public string[] waktu;
    public long[] total_status;
}
public class Check_status_code_occurence_per_ip : Day_data{
    public string keyword;
    public string[] ip_address;
    public long[] total_status;
}