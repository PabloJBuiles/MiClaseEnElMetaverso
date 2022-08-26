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

   public List<ToolQuestion> toolQuestions = new List<ToolQuestion>();

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
      for (int i = 0; i < 3; i++)
      {
         toolQuestions.Add(new ToolQuestion());
      }

      toolQuestions[0].ToolUtilities.Add(ToolUtility.Audacity);
      toolQuestions[0].question =
         "Debes de grabar un capítulo para un podcast en " +
         "clase ¿Qué herramienta deberías usar?";
      toolQuestions[1].ToolUtilities.Add(ToolUtility.AdobeAudition);
      toolQuestions[1].question =
         "•	Explorando encuentras una opción para ponerle un " +
         "poco más de nivel a tu edición ¿Qué herramienta puede" +
         " cumplir con esa función? ";
      toolQuestions[2].ToolUtilities.Add(ToolUtility.Audacity);
      toolQuestions[2].ToolUtilities.Add(ToolUtility.Anchor);
      toolQuestions[2].question =
         "Debes de grabar un capítulo para un podcast en " +
         "clase ¿Qué herramienta deberías usar?";
      
   }
   
   public void BasketTool(ToolUtility _toolUtility)
   {
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