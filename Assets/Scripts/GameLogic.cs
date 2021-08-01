using System;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [SerializeField] FieldsSriptableObjects player1;
    [SerializeField] FieldsSriptableObjects player2;
    [SerializeField] List<GameObject> ObjectToShowWin;
    [SerializeField] bool gameOver;
    private List<FieldBehaviour> fieldBehaviours;

    private bool firstPlayerTurn;
    

    private void OnEnable()
    {
        firstPlayerTurn = true;
        FieldBehaviour.OnMouseDownField += CheckForUptades;
        FieldCreator.OnInitFields += Init;
    }

    private void OnDisable()
    {
        FieldBehaviour.OnMouseDownField -= CheckForUptades;
        FieldCreator.OnInitFields -= Init;
    }
    private void Init(List<FieldBehaviour> fields)
    {
        fieldBehaviours = fields;
    }

    public static Action<string> OnPlayerChange;
    private void CheckForUptades(FieldBehaviour fieldBehaviour)
    {
        if (gameOver) return;
        if (fieldBehaviour.NamefieldName)
        {
            if (firstPlayerTurn) fieldBehaviour.Init(player1);
            else fieldBehaviour.Init(player2);

            firstPlayerTurn = !firstPlayerTurn;
            string playerName;
            if (firstPlayerTurn) playerName = player1.Name;
            else playerName = player2.Name;
            OnPlayerChange?.Invoke(playerName);

            CheckForWin(fieldBehaviour.Name);
        }
    }


    public void CheckForWin(string fieldName)
    {
        ColumnsCheck(fieldName);
        RawsCheck(fieldName);
        DiagonalCheck(fieldName);
    }
    public static Action<string> OnGameOver;
    #region CheckWin
    private void ColumnsCheck(string fieldName)
    {
        if (fieldBehaviours[0].Name == fieldName && fieldBehaviours[1].Name == fieldName && fieldBehaviours[2].Name == fieldName)
        {
            ObjectToShowWin[3].SetActive(true);
            OnGameOver?.Invoke(fieldName);
            gameOver = true;
        }
        if (fieldBehaviours[3].Name == fieldName && fieldBehaviours[4].Name == fieldName && fieldBehaviours[5].Name == fieldName)
        {
            ObjectToShowWin[4].SetActive(true);
            OnGameOver?.Invoke(fieldName);
            gameOver = true;
        }
        if (fieldBehaviours[6].Name == fieldName && fieldBehaviours[7].Name == fieldName && fieldBehaviours[8].Name == fieldName)
        {
            ObjectToShowWin[5].SetActive(true);
            OnGameOver?.Invoke(fieldName);
            gameOver = true;
        }
    }

    private void RawsCheck(string fieldName)
    {
        if (fieldBehaviours[0].Name == fieldName && fieldBehaviours[3].Name == fieldName && fieldBehaviours[6].Name == fieldName)
        {
            ObjectToShowWin[0].SetActive(true);
            OnGameOver?.Invoke(fieldName);
            gameOver = true;
        }
        if (fieldBehaviours[1].Name == fieldName && fieldBehaviours[4].Name == fieldName && fieldBehaviours[7].Name == fieldName)
        {
            ObjectToShowWin[1].SetActive(true);
            OnGameOver?.Invoke(fieldName);
            gameOver = true;
        }
        if (fieldBehaviours[2].Name == fieldName && fieldBehaviours[5].Name == fieldName && fieldBehaviours[8].Name == fieldName)
        {
            ObjectToShowWin[2].SetActive(true);
            OnGameOver?.Invoke(fieldName);
            gameOver = true;
        }
    }

    private void DiagonalCheck(string fieldName)
    {
        if (fieldBehaviours[0].Name == fieldName && fieldBehaviours[4].Name == fieldName && fieldBehaviours[8].Name == fieldName)
        {
            ObjectToShowWin[6].SetActive(true);
            OnGameOver?.Invoke(fieldName);
            gameOver = true;
        }
        if (fieldBehaviours[2].Name == fieldName && fieldBehaviours[4].Name == fieldName && fieldBehaviours[6].Name == fieldName)
        {
            ObjectToShowWin[7].SetActive(true);
            OnGameOver?.Invoke(fieldName);
            gameOver = true;
        }
    }
    #endregion //CheckWin
}
