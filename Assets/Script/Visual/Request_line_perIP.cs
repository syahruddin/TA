using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Request_line_perIP : MonoBehaviour
{
    public GameObject isi_prefab;
    public GameObject panel_isi;
    public Text current_ip,date_text,page_number;
    public Button seeAll,next_button,back_button;
    Get_request_line_and_status_code data;
    GameObject[] isi;
    int jumlah_baris = -1;
    int page = 0;
    int number_of_page = 0;

    // Start is called before the first frame update
    void Start()
    {
        seeAll.onClick.AddListener(delegate {search_ip_address(data.ip_address);});
        next_button.onClick.AddListener(delegate {next();});
        back_button.onClick.AddListener(delegate {back();});
    }

    void testing(){
        search_ip_address(2,2,2023,"213.225.9.98");
    }

    public void search_ip_address(string ip){
        StartCoroutine(get_request_by_ip(ip));
    }

    public void search_ip_address(int day, int month, int year, string ip){
        StartCoroutine(get_request_by_ip(day,month,year,ip));
    }
    IEnumerator get_request_by_ip(int day, int month, int year, string ip){
        string route = "get_request_line_and_status_code?year=" + year + "&month=" + month + "&day=" + day + "&ip_address=" + ip;
        string url = API_Connector.host + route;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if(www.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            string request = www.downloadHandler.text;
            data = JsonUtility.FromJson<Get_request_line_and_status_code>(request);
            //do something here
            page = 1;
            number_of_page = data.total_baris/100;
            if(data.total_baris % 100 > 0) number_of_page++;
            visualize();
        }
    }
    IEnumerator get_request_by_ip(string ip){
        string route = "get_request_line_and_status_code?ip_address=" + ip;
        string url = API_Connector.host + route;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if(www.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            string request = www.downloadHandler.text;
            data = JsonUtility.FromJson<Get_request_line_and_status_code>(request);
            //do something here
            page = 1;
            visualize();
        }
    }
    void visualize(){
        if(jumlah_baris > -1)destroy_all();
        current_ip.text ="IP Address: " + data.ip_address;
        if(data.timeless == 0){
            date_text.text = data.hari + "-" + data.bulan + "-" + data.tahun;
        }else{
            date_text.text = "";
        }
        jumlah_baris = data.total_baris;
        isi = new GameObject[jumlah_baris];
        int lastpage;
        if(page == number_of_page){
            lastpage = (page - 1)*100 + (jumlah_baris % 100);
        }else{
            lastpage = page*100;
        }
        for(int i = ((page-1)*100)+1; i <= lastpage; i++){
            isi[i-1] = Instantiate(isi_prefab,new Vector3(1,1,1),Quaternion.identity);
            isi[i-1].transform.SetParent(panel_isi.transform,false);
            isi[i-1].GetComponent<Info_line>().update_text(data.waktu[i-1],data.request_line[i-1],data.status_code[i-1].ToString(),i);
        }
        page_number.text = "Page " + page + " of " + number_of_page + "\n" + jumlah_baris +" entry" ;
        
    }
    void destroy_all(){
        foreach(GameObject baris in isi){
            Destroy(baris);
        }
    }
    void back(){
        if(page > 1){
            page--;
            visualize();
        }
    }
    void next(){
        if(page < number_of_page){
            page++;
            visualize();
        }
    }
}
