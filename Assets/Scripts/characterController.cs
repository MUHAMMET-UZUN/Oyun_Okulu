using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class characterController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;

    private Vector2 touchStartPos;
    private float minSwipeDistance = 50f;
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
        if (Input.touchCount > 0) // Detect touch input
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Began) // Detect touch start
            {
                touchStartPos = touch.position; // Store the starting position of the touch
            }

            if (touch.phase == TouchPhase.Ended) // Detect touch end
            {
                Vector2 touchEndPos = touch.position; // Store the ending position of the touch

                // Calculate the distance between start and end positions
                float swipeDistance = Vector2.Distance(touchStartPos, touchEndPos);

                // Check if the swipe distance is greater than the minimum required distance
                if (swipeDistance > minSwipeDistance)
                {
                    // Determine the direction of the swipe
                    Vector2 swipeDirection = touchEndPos - touchStartPos;

                    if (swipeDirection.x > 0) // Swiped to the right
                    {
                        if (transform.position.x < 3)
                        {
                            Debug.Log("Swiped to the right");
                            Vector3 newPosition = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
                            transform.position = newPosition;
                        }
                       
                    }
                    else if (swipeDirection.x < 0) // Swiped to the left
                    {
                        if (transform.position.x > -3)
                        {
                            Debug.Log("Swiped to the left");
                            Vector3 newPosition = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z);
                            transform.position = newPosition;
                        }
                    }
                }
            }
        }
    }
 
}
