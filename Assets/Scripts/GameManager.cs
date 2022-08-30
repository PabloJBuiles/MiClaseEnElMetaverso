using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static int points;
    // Start is called before the first frame update
    void Start()
    {
        ShowPoints();
    }

    public static int PointsEarned()
    {
        return points;
    }

    public static void CorrectAnswerPoints()
    {
        points += 200;
        ShowPoints();

    }
    
    public static void CorrectToolPointsFirstAttempt()
    {
        points += 1000;
        ShowPoints();

    }
    
    public static void CorrectToolPoints()
    {
        points += 500;
        ShowPoints();

    }
    
    public static void CorrectPaidTool()
    {
        points += 5000;
        ShowPoints();

    }
    
    public static bool BuyPaidTool()
    {
        if (points >= 100)
        {
            points -= 100;
            ShowPoints();
            return true;
        }
        ShowPoints();

        return false;
    }
    public static bool BuyItem(int itemPrice)
    {
        if (points >= itemPrice)
        {
            points -= itemPrice;
            ShowPoints();

            return true;
        }

        return false;
    }

    public static void ShowPoints()
    {
        GameObject.Find("PointsText").GetComponent<Text>().text = "Puntos:  " + points;
    }
}
