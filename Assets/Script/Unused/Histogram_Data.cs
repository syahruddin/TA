public class Histogram_Data
{
    int highest_val; //angka kemunculan tertinggi (untuk patokan ukuran histrogram)
    int x,y;
    int[,] data_value;

    public Histogram_Data(int x, int y){
        highest_val = 0;
        create_matrix(x,y);
    }
    void create_matrix(int x, int y){
        this.x = x;
        this.y = y;
        data_value = new int[x,y];
    }
    public void change_data(int x, int y, int value){
        if(x <= this.x && y <= this.y){
            data_value[x-1,y-1] = value;
            if(value > highest_val){
                highest_val = value;
            }
        }
    }
    public int get_value(int x, int y){
        return data_value[x-1,y-1];
    }
    public int get_highest_val(){
        return highest_val;
    }
    public int get_x(){
        return x;
    }
    public int get_y(){
        return y;
    }
}
