using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info_line : MonoBehaviour
{
    public Text time_UI, request_line_UI,status_code_UI;
    public int index;
    public string time,request_line,status_code;


    public void update_text(string time,string request_line,string status_code,int index){
        this.index=index;
        this.time = time;
        this.request_line = request_line;
        this.status_code = status_code;
        time_UI.text = time;
        request_line_UI.text = request_line;
        status_code_UI.text = status_code;
    }
}
