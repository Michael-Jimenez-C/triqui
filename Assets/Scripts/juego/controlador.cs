using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class controlador : MonoBehaviour
{
    public GameObject celda;
    private GameObject[,] game_cells = new GameObject[3,3];
    public int current_player = 1;
    private int[] win = {0,0};
    public float timer = 5f;
    private int wins = 0;

    void Start()
    {   
        Debug.Log(GetText());
        restart();
    }

    void restart(){
        for (int x = 0; x < 3; x++)
            for (int y=0; y<3; y++){
                if (game_cells[x,y]!=null)
                    Destroy(game_cells[x,y]);
                game_cells[x,y] = Instantiate(celda, new Vector3(-2.5f+2.6f*x, 1.8f - 2.6f*y, 0), Quaternion.identity);
                game_cells[x,y].GetComponent<celda>().master = gameObject;
        }
    }

    void Update()
    {
        Validation();
        gameObject.GetComponent<gui>().setMarcador("Marcador: "+win[0]+" - "+win[1]);
        gameObject.GetComponent<gui>().setCurrentPlayer("Jugador: "+((current_player==1)? 1:2));
        timer = timer - Time.deltaTime;
        timer = (timer<0)? 0: timer;
        if (timer == 0){
            gameObject.GetComponent<gui>().setWinner("");
        }
        if (wins ==3){
            StartCoroutine(Send());
            StartCoroutine(GetText());
            wins = 0;
            win[0]=0;
            win[1]=0;
        }
    }

    void Validation(){
        int sumh=0;
        int sumv=0;
        bool active_cells = false;
        for (int i=0;i<3; i++){
            sumh=0;
            sumv=0;
            for(int j=0;j<3;j++){
                sumh+=game_cells[i,j].GetComponent<celda>().state;
                sumv+=game_cells[j,i].GetComponent<celda>().state;
                active_cells = active_cells || game_cells[i,j].GetComponent<celda>().active;
            }
            if (sumh == 3 || sumh == -3 || sumv == 3 || sumv == -3)
                break;
        }
        int sumd1=0;
        int sumd2=0;
        int ganador = 0;
        for (int i=0;i<3;i++){
            sumd1+=game_cells[i,i].GetComponent<celda>().state;
            sumd2+=game_cells[2-i,i].GetComponent<celda>().state;
            }
        if (sumh==3 || sumv==3 || sumd1==3 || sumd2==3){
            win[0]+=1;
            ganador = 1;
            restart();
        }else if (sumh==-3 || sumv==-3 || sumd1==-3 || sumd2==-3){
            win[1]+=1;
            ganador = 2;
            restart();
        }else if (!active_cells){
            restart();
            ganador = 3;
        }
        if (ganador != 0){
            gameObject.GetComponent<gui>().setWinner((ganador ==3)? "Empate":("Ganador: " + ((ganador ==1)? "X":"O")));
            wins += 1;
        }
    }

    public void Change(){
        current_player*=-1;
    }

    IEnumerator GetText() {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8000/")) {
            yield return www.SendWebRequest();
            string data = www.downloadHandler.text;
            gameObject.GetComponent<gui>().setFetched(data);
        }
    }

    IEnumerator Send() {
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/"+win[0]+"/"+win[1],"{ \"field1\": 1, \"field2\": 2 }", "application/json")) {
            yield return www.SendWebRequest();
        }
    }
}
