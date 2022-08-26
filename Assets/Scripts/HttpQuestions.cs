using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OVRSimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

public class HttpQuestions : MonoBehaviour
{
    public string NumeroPregunta;
    public string Preguntas;
    public string RespuestaCorrecta;
    public string RespuestaErrada1;
    public string RespuestaErrada2;

    public string URL;
    private readonly string url = "https://sheet2api.com/v1/cIjmMYYqS5eu/preguntas/";
    public List<QuestionList> questionList = new List<QuestionList>();
    private IList<QuestionList> preguntasList = new List<QuestionList>();
    public QuestionList[] pregunta;
    public JSONArray JsonArray;


    private IEnumerator GetQuestions()
    {
        var www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.error == null)
        {
           // Debug.Log(www.downloadHandler.text);
           // Debug.Log(www.responseCode);

            // string filePath = Application.dataPath + "/StreamingAssets" + "/preguntas.json";

            var dataAsJson = www.downloadHandler.text;

            //pregunta = JsonHelper.FromJson<QuestionList>(dataAsJson);
            //Debug.Log(pregunta[0].Preguntas);

            // Questions resData = JsonUtility.FromJson<Questions>(www.downloadHandler.text);
            /*
           JsonTextReader reader = new JsonTextReader(new StreamReader(dataAsJson));
           reader.SupportMultipleContent = true;
           while (true)
           {
               if (!reader.Read())
               {
                   break;
               }

               JsonSerializer serializer = new JsonSerializer();
               QuestionList question_list = serializer.Deserialize<QuestionList>(reader);
               preguntasList.Add(question_list);
           }

           foreach (QuestionList question_list in preguntasList)
           {
               print(question_list.NumeroPregunta);
           }*/
            var json = @"[{ 'name': 'Admin' }{ 'name': 'Publisher' }]";

            IList<Role> roles = new List<Role>();

            var reader = new JsonTextReader(new StringReader(json));
            reader.SupportMultipleContent = true;


            pregunta = JsonHelper.getJsonArray<QuestionList>(dataAsJson);

            Debug.Log(pregunta[0].Preguntas);
            for (var i = 0; i < pregunta.Length; i++) questionList.Add(pregunta[i]);

            if (questionList != null) GameObject.Find("GameManager").GetComponent<TestManager>().GetQuetionsList();
        }
        else
        {
            Debug.Log(www.error);
        }
    }

    public List<QuestionList> GetPreguntasList()
    {
        return questionList;
    }


    private void Start()
    {
        StartCoroutine(GetQuestions());
    }
}

[Serializable]
public class Questions
{
    public QuestionList[] questions;
}

public static class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        var newJson = "{ \"array\": " + json + "}";
        var wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}

public class Role
{
    public string Name { get; set; }
}