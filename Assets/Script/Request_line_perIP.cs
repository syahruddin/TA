using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Request_line_perIP : MonoBehaviour
{
    public GameObject isi_prefab;
    public GameObject panel_isi;
    public Text current_ip,date_text;
    Get_request_line_and_status_code data;
    GameObject[] isi;
    int jumlah_baris = -1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void testing(){
        search_ip_address(2,2,2023,"213.225.9.98");
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
            visualize();
        }
    }
    void visualize(){
        if(jumlah_baris > -1)destroy_all();
        current_ip.text ="IP Address: " + data.ip_address;
        date_text.text = data.hari + "-" + data.bulan + "-" + data.tahun;
        jumlah_baris = data.total_baris;
        isi = new GameObject[jumlah_baris];
        for(int i = 1; i <= jumlah_baris; i++){
            isi[i-1] = Instantiate(isi_prefab,new Vector3(1,1,1),Quaternion.identity);
            isi[i-1].transform.SetParent(panel_isi.transform,false);
            isi[i-1].GetComponent<Info_line>().update_text(data.waktu[i-1],data.request_line[i-1],data.status_code[i-1].ToString(),i);
        }
        
    }
    void destroy_all(){
        foreach(GameObject baris in isi){
            Destroy(baris);
        }
    }
}
