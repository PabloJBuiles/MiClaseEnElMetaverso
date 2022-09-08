using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    private new List<QuestionList>  _questions;
    private int nextQuestion;
    private bool toolQuestion = false;

   [SerializeField] Answer[] answer = new Answer[3];
   [SerializeField] private UnityEvent PreguntaDeLanzamiento;
   


        // Start is called before the first frame update
    void Start()
    {
 

    }

    public void GetQuetionsList()
    {
        _questions = gameObject.GetComponentInChildren<HttpQuestions>().GetPreguntasList();
        RamdomQuestions();
        RamdomQuestions();
        NextQuestion();
    }

    public bool QuestionBeforeTools(int numero)
    {
        return (numero + 1) % 5 == 0;
    }
    public void AddQuestionListElement(QuestionList question)
    {
        _questions.Add(question);
    }

    public void NextQuestion() //Mustra la siguiente pregunta
    {
        if (!QuestionBeforeTools(nextQuestion) || toolQuestion)
        {
            //Debug.Log(QuestionBeforeTools(nextQuestion) + "             "+ toolQuestion);
            MostrarPregunta(nextQuestion);
            nextQuestion++;
            toolQuestion = false;
        }
        else
        {
            //Debug.Log(QuestionBeforeTools(nextQuestion) + "             "+ toolQuestion + "pregunta multiplo de 5");

            PreguntaDeLanzamiento.Invoke();
            toolQuestion = true;
        }
    }
    

    void MostrarPregunta(int numeroPregunta)
    {
        Text pregunta = GameObject.Find("Text_Pregunta").GetComponent<Text>();
        pregunta.text = _questions[numeroPregunta].Preguntas;
        ChangeAnswerValues(numeroPregunta);
        Canvas.ForceUpdateCanvases();
        pregunta.gameObject.SetActive(false);
        pregunta.gameObject.SetActive(true);

    }
    public void ChangeAnswerValues(int question)
    {
        
        
        int[] preguntasUsadas = new int[3];
        preguntasUsadas[0] = 4;
        preguntasUsadas[2] = 4;
        preguntasUsadas[1] = 4;
        int valorPregunta;
        int index = 0;

        valorPregunta = Random.Range(0, 3);
        answer[valorPregunta].GetAnsewr(_questions[question].RespuestaCorrecta, true);
        preguntasUsadas[valorPregunta] = valorPregunta;
        valorPregunta = Random.Range(0, 3);
        int antibucle = 0;

        while (index == 0)
        {
            if (!((IList) preguntasUsadas).Contains(valorPregunta))
            {
                preguntasUsadas[index] = valorPregunta;
                answer[valorPregunta].GetAnsewr(_questions[question].RespuestaErrada1, false);

                index++;
            }
            else
            {
                valorPregunta = Random.Range(0, 3);
            }
            if (antibucle > 100)
            {
                print("anti bucle 1 ejecutado");

                break;
            }

            antibucle++;
        }
         antibucle = 0;
         valorPregunta = Random.Range(0, 3);
         while (index == 1)
        {
            if (!((IList) preguntasUsadas).Contains(valorPregunta))
            {
                preguntasUsadas[index] = valorPregunta;
                answer[valorPregunta].GetAnsewr(_questions[question].RespuestaErrada2, false);

                index++;
            }
            else
            {
                valorPregunta = Random.Range(0, 3);
                print(valorPregunta);
            }
            
            if (antibucle > 100)
            {
                print("anti bucle 2 ejecutado");

                break;
            }

            antibucle++;
        }
         print(preguntasUsadas.Length);
         Canvas.ForceUpdateCanvases();


    }

    public void RamdomQuestions()
    {
        int index = 0;
        int valorPregunta;
        index = 0;
        valorPregunta = Random.Range(0, _questions.Count);
        QuestionList[] usedQuestions = new QuestionList[_questions.Count];

        int antibucle = 0;
        while (index < usedQuestions.Length)
        {
            if (!((IList) usedQuestions).Contains(_questions[valorPregunta]))
            {
                usedQuestions[index] = _questions[valorPregunta];
                //print("Se agrego la pregunta" + usedQuestions[index].Preguntas);

                index++;
            }
            else
            {
                valorPregunta = Random.Range(0, _questions.Count);
               // print(valorPregunta + "  " + _questions.Count);

            }

            if (antibucle > 1000)
            {
                //print("anti bucle ejecutado");

                break;
            }

            antibucle++;
        }
        for (int i = 0; i < _questions.Count; i++)
        {
            _questions[i] = usedQuestions[i];
            //print("La respuesta " + i + " es" + usedQuestions[i].RespuestaCorrecta);

        }


    }

    // Update is called once per frame

    public void GradeAnswer(bool good, string answerTxt)
    {
        ShowAnswerd(answerTxt);
        if (good)
        {
            CorrectAnswer();
        }
        else
        {
            BadAnswer();
        }
    }
    
    public void CorrectAnswer()
    {
        GameManager.CorrectAnswerPoints();
        GameObject.Find("Prefab_MSG_End").GetComponentInChildren<Text>().text = "Listo," +
            " muchas gracias! me ayudaste mucho!";
    }

    public void BadAnswer()
    {
        GameObject.Find("Prefab_MSG_End").GetComponentInChildren<Text>().text = "Tengo la certeza" +
            " que que puedo hacer algo mejor, le pedire ayuda a otra persona, aunque no me ayudaste igual Gracias";
    }

    void ShowAnswerd(string answerTxt)
    {
        GameObject.Find("Prefab_MSG_Answer").GetComponentInChildren<Text>().text = answerTxt;
    }
    
}
