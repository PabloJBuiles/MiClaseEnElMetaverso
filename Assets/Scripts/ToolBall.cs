using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolUtility
{
    Audacity, AdobeAudition, Anchor, Freesound, Jamendo, Screencast, Filmora, AdobeAfterEffects, Canva, Piktochart, Sutori, Miro, Ludichart, AdobeIllustrator
        
        
}
public class ToolBall : MonoBehaviour
{
    [SerializeField] private ToolUtility _toolUtility;

    [SerializeField] private float cdBasketUp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cdBasketUp += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) ToolReturn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UpBasket"))
        {
            cdBasketUp = 0;
        }

        if (other.CompareTag("DownBasket") && cdBasketUp > 0.2f)
        {
            GameObject.Find("GameManager").GetComponent<ToolBallsManager>().BasketTool(_toolUtility);
        }
    }

    private static void ToolReturn()
    {
        
            //TODO Se destrulle la herramienta (visualmente) y vuelve a su posicion inicial en el escaparate
        
    }
}
