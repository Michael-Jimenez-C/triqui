using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gui : MonoBehaviour
{
    public TextMeshProUGUI marcador;
    public TextMeshProUGUI current_player;
    public TextMeshProUGUI winner;
    public TextMeshProUGUI fetched;

    public void setMarcador(string text){
        marcador.text = text;
    }

    public void setCurrentPlayer(string text){
        current_player.text = text;
    }

    public void setWinner(string text){
        winner.text = text;
    }

    public void setFetched(string text){
        fetched.text = text;
    }
}
