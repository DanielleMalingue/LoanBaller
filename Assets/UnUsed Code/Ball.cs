using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public GameObject greenBall; 
    public float ringDevSpeed = 1f;
    public Color strokeColor = Color.gray; // Color for the stroke

    private bool isTouching = false;
    private float touchStartTime = 0f;
    private GameObject currentStroke;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (hit.collider != null && hit.collider.gameObject == gameObject)
                    {
                        isTouching = true;
                        touchStartTime = Time.time;
                        CreateCircleStroke(touchPos);
                    }
                    break;

                case TouchPhase.Ended:
                    if (isTouching && currentStroke != null)
                    {
                        Destroy(currentStroke, 5f);
                        isTouching = false;
                    }
                    break;
            }
        }

        if (isTouching && Time.time - touchStartTime >= 5f)
        {
            isTouching = false;
            // Change the stroke color to a lighter color
            currentStroke.GetComponent<SpriteRenderer>().color = strokeColor;
        }

        if (isTouching)
        {
            UpdateCircleStroke();
        }
    }

    void CreateCircleStroke(Vector3 position)
    {
        currentStroke = Instantiate(greenBall, position, Quaternion.identity);
        currentStroke.transform.localScale = Vector3.zero;
    }

    void UpdateCircleStroke()
    {
        float scaleFactor = ringDevSpeed * Time.deltaTime;
        currentStroke.transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);

        float maxScale = transform.localScale.x;
        currentStroke.transform.localScale = Vector3.Min(currentStroke.transform.localScale, new Vector3(maxScale, maxScale, maxScale));
    }
}
