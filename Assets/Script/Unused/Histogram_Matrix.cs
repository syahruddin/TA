using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Histogram_Matrix : MonoBehaviour
{
    [SerializeField]
    int x_length = 2;
    [SerializeField]
    int y_length = 2;
    [SerializeField]
    int[,] data = new int[2,2]{{1,1},{1,1}};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateArraySize();
    }
    int[,] CreateEmptyArray(int x, int y){
        int[,] temp = new int[x_length, y_length];
        return temp;
    }
    void updateArraySize(){
        if(x_length > 0 & y_length > 0){
            data = CreateEmptyArray(x_length,y_length);
        }
    }

}
