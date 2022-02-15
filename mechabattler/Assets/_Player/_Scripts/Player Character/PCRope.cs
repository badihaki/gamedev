using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCRope : MonoBehaviour
{
    [Header("General Refernces:")]
    public PCGrappleGun grapplingGun;
    public LineRenderer m_lineRenderer;

    [Header("General Settings:")]
    [SerializeField] private int percision = 40;
    [Range(0, 20)] [SerializeField] private float straightenLineSpeed = 5;

    [Header("Rope Animation Settings:")]
    public AnimationCurve ropeAnimationCurve;
    [Range(0.01f, 4)] [SerializeField] private float StartWaveSize = 2;
    float waveSize = 0;

    [Header("Rope Progression:")]
    public AnimationCurve ropeProgressionCurve;
    [SerializeField] [Range(1, 50)] private float ropeProgressionSpeed = 1;

    float moveTime = 0;

    [HideInInspector] public bool isGrappling = true;

    bool strightLine = true;

    private void OnEnable()
    {
        if (grapplingGun != null)
        {
            moveTime = 0;
            m_lineRenderer.positionCount = percision;
            waveSize = StartWaveSize;
            strightLine = false;

            LinePointsToFirePoint();

            m_lineRenderer.enabled = true;
        }
    }

    private void OnDisable()
    {
        m_lineRenderer.enabled = false;
        isGrappling = false;
    }

    private void Awake()
    {
        grapplingGun = GetComponentInParent<PCGrappleGun>();
        m_lineRenderer = GetComponent<LineRenderer>();   
    }
    private void Update()
    {
        moveTime += Time.deltaTime;
        DrawRope();
    }

    private void LinePointsToFirePoint()
    {
        for (int i = 0; i < percision; i++)
        {
            m_lineRenderer.SetPosition(i, grapplingGun.firePoint.position);
        }
    }

    void DrawRope()
    {
        if (!strightLine)
        {
            if (m_lineRenderer.GetPosition(percision - 1).x == grapplingGun.grapplePoint.x)
            {
                // if the last point of linerenderer is on the grapple point, we straighten the line
                strightLine = true;
            }
            else
            {
                // lets call draw waves function
                DrawRopeWaves();
            }
        }
        else
        {
            if (!isGrappling)
            {
                grapplingGun.Grapple();
                isGrappling = true;
            }
            if (waveSize > 0)
            {
                waveSize -= Time.deltaTime * straightenLineSpeed;
                DrawRopeWaves();
            }
            else
            {
                waveSize = 0;

                if (m_lineRenderer.positionCount != 2) { m_lineRenderer.positionCount = 2; }

                DrawRopeNoWaves();
            }
        }
    }

    void DrawRopeWaves()
    {
        for (int i = 0; i < percision; i++)
        {
            float delta = (float)i / ((float)percision - 1f);
            Vector2 offset = Vector2.Perpendicular(grapplingGun.grappleDistanceVector).normalized * ropeAnimationCurve.Evaluate(delta) * waveSize;
            Vector2 targetPosition = Vector2.Lerp(grapplingGun.firePoint.position, grapplingGun.grapplePoint, delta) + offset;
            Vector2 currentPosition = Vector2.Lerp(grapplingGun.firePoint.position, targetPosition, ropeProgressionCurve.Evaluate(moveTime) * ropeProgressionSpeed);

            m_lineRenderer.SetPosition(i, currentPosition);
        }
    }

    void DrawRopeNoWaves()
    {
        m_lineRenderer.SetPosition(0, grapplingGun.transform.position);
        m_lineRenderer.SetPosition(1, grapplingGun.grapplePoint);
    }
}
