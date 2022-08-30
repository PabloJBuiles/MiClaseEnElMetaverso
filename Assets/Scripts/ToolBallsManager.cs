using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToolBallsManager : MonoBehaviour
{
   [SerializeField]private UnityEvent CorrectBasketedTool_UE;
   [SerializeField]private UnityEvent WrongBasketedTool_UE;
   private Text questionText;

   private int questionId = 0;

   [SerializeField] public List<ToolQuestion> toolQuestions = new List<ToolQuestion>();

   private void Start()
   {
      questionText = GameObject.Find("ToolQuestionText").GetComponent<Text>();
      questionText.gameObject.SetActive(false);
      QuestionBuilder();
   }

   public void ToolBallMiniGameStart()
   {
      questionText.gameObject.SetActive(true);
      questionText.text = toolQuestions[questionId].question;
   }
   public void QuestionBuilder()
   {
      
      for (int i = 0; i < 11; i++)
      {
         toolQuestions.Add(new ToolQuestion());
      }

      Debug.Log(toolQuestions.Count);

      toolQuestions[0].ToolUtilities.Add(ToolUtility.Audacity);
      toolQuestions[0].question =
         "Debes de grabar un capítulo para un podcast en " +
         "clase ¿Qué herramienta deberías usar?";
      toolQuestions[1].ToolUtilities.Add(ToolUtility.AdobeAudition);
      toolQuestions[1].question =
         "Explorando encuentras una opción para ponerle un " +
         "poco más de nivel a tu edición ¿Qué herramienta puede" +
         " cumplir con esa función? ";
      toolQuestions[2].ToolUtilities.Add(ToolUtility.Audacity);
      toolQuestions[2].ToolUtilities.Add(ToolUtility.Anchor);
      toolQuestions[2].question =
         "Debes de grabar un capítulo para un podcast en " +
         "clase ¿Qué herramienta deberías usar?";
      toolQuestions[3].ToolUtilities.Add(ToolUtility.Freesound);
      toolQuestions[3].ToolUtilities.Add(ToolUtility.Jamendo);
      toolQuestions[3].question =
         "Editaste el capítulo, pero sientes que falta agregar" +
         " sonidos de fondo y música que acompañe el capítulo ¿De" +
         " dónde puedes sacarlas? Lanza una herramienta y luego la otra.";
      toolQuestions[4].ToolUtilities.Add(ToolUtility.Screencast);
      toolQuestions[4].question =
         " Necesitas grabar la pantalla de tu computador para" +
         " enseñarle a un compañero como se hace un proceso en el" +
         " computador ¿Qué herramienta puedes usar?";
      toolQuestions[5].ToolUtilities.Add(ToolUtility.Filmora);
      toolQuestions[5].question =
         "¡Necesitas editar un vídeo de manera rápida!" +
         " ¿Qué herramienta puedes usar para ello?";
      toolQuestions[6].ToolUtilities.Add(ToolUtility.AdobeAfterEffects);
      toolQuestions[6].question =
         "Deseas crear un gran proyecto de vídeo para una clase," +
         " pero necesitas añadirle algo de profesionalidad " +
         "¿Qué herramienta podría brindarte esta opción?";
      toolQuestions[7].ToolUtilities.Add(ToolUtility.Canva);
      toolQuestions[7].ToolUtilities.Add(ToolUtility.Piktochart);
      toolQuestions[7].question =
         " Para una clase han pedido que hagas una infografía " +
         "¿Qué herramientas pueden serte útiles?";
      toolQuestions[8].ToolUtilities.Add(ToolUtility.Sutori);
      toolQuestions[8].question =
         "Debes hacer una línea de tiempo para mostrar los " +
         "avances de un trabajo ¿Alguna aplicación que pueda " +
         "serte útil?";
      toolQuestions[9].ToolUtilities.Add(ToolUtility.Miro);
      toolQuestions[9].ToolUtilities.Add(ToolUtility.Ludichart);
      toolQuestions[9].question =
         "Hacer mapas mentales y conceptuales en computador" +
         " puede ser complicado, pero existen aplicaciones para " +
         "facilitar la tarea ¿Conoces algunas?";
      toolQuestions[10].ToolUtilities.Add(ToolUtility.AdobeIllustrator);
      toolQuestions[10].question =
         "DDeseas crear y compartir a tus amigos y compañeros " +
         "tus ilustraciones e infografías de manera editable ¿Qué " +
         "herramienta podría brindarte algo así?";


   }
   
   public void BasketTool(ToolUtility _toolUtility, ToolBall toolBall)
   {
      Debug.Log(_toolUtility.ToString() + " ==? " + toolQuestions[questionId].ToolUtilities[0]+" pregunta numero" + questionId);
      bool correctAnswer = false;
      foreach (var VARIABLE in 
               toolQuestions[questionId].ToolUtilities)
      {
         if (VARIABLE == _toolUtility)
         {
            correctAnswer = true;
            break;
         }
         else
         {
            correctAnswer = false;
         }
      }

      if (correctAnswer)
      {
         CorrectBasketedTool_UE.Invoke();
         toolBall.ToolReturn();
         GameManager.CorrectToolPoints();
         questionId++;
      }
      else
      {
         WrongBasketedTool_UE.Invoke();
      }

   }
}


public class ToolQuestion
{
   public string question;
   public List<ToolUtility> ToolUtilities = new List<ToolUtility>();
}