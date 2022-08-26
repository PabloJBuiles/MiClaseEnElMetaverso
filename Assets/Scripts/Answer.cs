using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    private TestManager _testManager;
    private string bodyAnswer;
    private bool goodAnswer;
    [SerializeField]private Text bodyText;

    public bool GoodAnswer => goodAnswer;

    private void Awake()
    {
        bodyText = GetComponentInChildren<Text>();
        _testManager = GameObject.Find("GameManager").GetComponent<TestManager>();
        
    }

    public void GetAnsewr(string answer, bool good)
    {
        bodyAnswer = answer;
        goodAnswer = good;
        bodyText = GetComponentInChildren<Text>();
        bodyText.text = answer;
        if (bodyText.text != answer)
        {
            ActualizarRespuesta();
        }
    }

    public void SendAnswer()
    {
        _testManager.GradeAnswer(goodAnswer, bodyAnswer);
    }

    void ActualizarRespuesta()
    {
        bodyText = GetComponentInChildren<Text>();
        bodyText.text = bodyAnswer + "Respuesta actualizada";
    }
}
