using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class characterController : MonoBehaviour
{

    public float moveSpeed = 5f;

    [SerializeField] GameObject collectEffect;

    private Vector2 touchStartPos;
    private float minSwipeDistance = 50f;
    private float xOffset = 2.5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        touchCheck();
    }

    void movement()
    {
        Vector3 ileriHareket = transform.forward * moveSpeed * Time.deltaTime;
        transform.position += ileriHareket;
    }

    void touchCheck()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                Vector2 touchEndPos = touch.position;


                float swipeDistance = Vector2.Distance(touchStartPos, touchEndPos);


                if (swipeDistance > minSwipeDistance)
                {

                    Vector2 swipeDirection = touchEndPos - touchStartPos;

                    if (swipeDirection.x > 0)
                    {
                        if (transform.position.x < xOffset)
                        {

                            Vector3 newPosition = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z);
                            transform.position = newPosition;
                        }

                    }
                    else if (swipeDirection.x < 0)
                    {
                        if (transform.position.x > -xOffset)
                        {

                            Vector3 newPosition = new Vector3(transform.position.x - xOffset, transform.position.y, transform.position.z);
                            transform.position = newPosition;
                        }
                    }
                }
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "targetLetter")
        {
            Debug.Log("Correct");
            GameObject instantiatedLetter = Instantiate(collectEffect);
            instantiatedLetter.transform.position = other.transform.position;
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Worse");
        }
    }

}
