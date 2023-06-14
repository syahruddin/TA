using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;

public class REST_TEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:5000/test");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        Debug.Log(reader.ReadToEnd());
    }

}
