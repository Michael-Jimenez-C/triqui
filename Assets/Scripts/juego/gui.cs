using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gui : MonoBehaviour
{
    public TextMeshProUGUI marcador;
    public TextMeshProUGUI current_player;

    public void setMarcador(string text){
        marcador.text = text;
    }

    public void setCurrentPlayer(string text){
        current_player.text = text;
    }
}
