using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        initialPosition = gameObject.GetComponent<Transform>().position;

    }

    public Vector3 initialPosition { get; set; }

    
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
        Debug.Log(other.gameObject);
        if (other.CompareTag("UpBasket"))
        {
            cdBasketUp = 0;
        }

        if (other.CompareTag("DownBasket") && cdBasketUp < 0.2f)
        {
            Debug.Log("Pelota encestada");
            GameObject.Find("GameManager").GetComponent<ToolBallsManager>().BasketTool(_toolUtility, gameObject.GetComponent<ToolBall>());
        }
    }

    public void ToolReturn()
    {
        
            //TODO Se destrulle la herramienta (visualmente) 
            this.transform.position = initialPosition;
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;

    }
}
