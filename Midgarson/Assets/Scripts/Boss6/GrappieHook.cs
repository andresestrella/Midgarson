using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappieHook : MonoBehaviour
{
    LineRenderer line;

    [SerializeField] LayerMask grapplableMask;
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float grappleSpeed = 10f;
    [SerializeField] float grappleShootSpeed = 20f;

    bool isGrappling = false;
    [HideInInspector] public bool retracting = false;

    Vector2 target;

    public Transform player;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        player = GameObject.Find("Player 1").GetComponent<Transform>();
    }

    private void Update()
    {
       // if (Input.GetMouseButtonDown(0) && !isGrappling)
       // {
          //  print("hola");
          //  StartGrapple();
      //  }

        if (retracting)
        {
            Vector2 grapplePos = Vector2.Lerp(transform.position, target, grappleSpeed * Time.deltaTime);
            grapplePos.y = -2.83f;
            transform.position = grapplePos;

            line.SetPosition(0, transform.position);

            if (Vector2.Distance(transform.position, target) < 0.5f)
            {
                retracting = false;
                isGrappling = false;
                line.enabled = false;
            }
        }
    }

    public void StartGrapple()
    {
       // Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 direction = player.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, grapplableMask);

        if (hit.collider != null)
        {
            isGrappling = true;
            target = hit.point;
            line.enabled = true;
            line.positionCount = 2;

            StartCoroutine(Grapple());
        }
    }

    IEnumerator Grapple()
    {
        float t = 0;
        float time = 10;

        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position);

        Vector2 newPos;

        for (; t < time; t += grappleShootSpeed * Time.deltaTime)
        {
            newPos = Vector2.Lerp(transform.position, target, t / time);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, newPos);
            yield return null;
        }

        line.SetPosition(1, target);
        retracting = true;
    }
}

