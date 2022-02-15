using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCGrappleGun : MonoBehaviour
{
    [Header("Scripts Ref:")]
    public PCRope grappleRope;
    public PlayerInputInterface controls;

    [Header("Layers Settings:")]
    [SerializeField] private bool grappleToAll = false;
    [SerializeField] private int grappableLayerNumber = 9;

    [Header("Main Camera:")]
    public Camera m_camera;

    // Transform Refs
    public Transform player;
    public Transform gunPivot;
    public Transform firePoint;
    // 

    [Header("Physics Ref:")]
    public SpringJoint2D m_springJoint2D;
    public Rigidbody2D m_rigidbody;
    public float originalGravScale;

    [Header("Rotation:")]
    [SerializeField] private bool rotateOverTime = true;
    [Range(0, 60)] [SerializeField] private float rotationSpeed = 4;

    [Header("Distance:")]
    [SerializeField] private bool hasMaxDistance = false;
    [SerializeField] private float maxDistnace = 20;

    private enum LaunchType
    {
        Transform_Launch,
        Physics_Launch
    }

    [Header("Launching:")]
    [SerializeField] private bool launchToPoint = true;
    [SerializeField] private LaunchType launchType = LaunchType.Physics_Launch;
    [SerializeField] private float launchSpeed = 1;

    [Header("No Launch To Point")]
    [SerializeField] private bool autoConfigureDistance = false;
    [SerializeField] private float targetDistance = 3;
    [SerializeField] private float targetFrequncy = 1;

    public Vector2 grapplePoint;
    [HideInInspector] public Vector2 grappleDistanceVector;

    private void Start()
    {
        player = GetComponentInParent<PCProperties>().transform;
        grappleRope = GetComponentInChildren<PCRope>();
        firePoint = grappleRope.transform;
        gunPivot = transform.Find("GrappleGun").transform;
        m_springJoint2D = player.GetComponent<SpringJoint2D>();
        controls = GetComponentInParent<PCProperties>().player.Controls;
        m_rigidbody = player.GetComponent<Rigidbody2D>();
        originalGravScale = m_rigidbody.gravityScale;
        m_camera = Camera.main;

        grappleRope.enabled = false;
        m_springJoint2D.enabled = false;
    }

    private void Update()
    {
        /* 
         * 2 grapple states
         * 1. We gotta find the grapple point when the player presses the grapple button
         *  - 
        if (controls.AltFireButton)
        {
            // first click to set grapple point
            if (controls.TetherCancel == false)
            {
                SetGrapplePoint();
            }
            else if (controls.TetherCancel == true)
            {
                if (grappleRope.enabled)
                {
                    RotateGun(grapplePoint, false);
                }
                else
                {
                    RotateGun(controls.AimInput, true);
                }

                if (launchToPoint && grappleRope.isGrappling)
                {
                    if (launchType == LaunchType.Transform_Launch)
                    {
                        Vector2 firePointDistnace = firePoint.position - player.localPosition;
                        Vector2 targetPos = grapplePoint - firePointDistnace;
                        player.position = Vector2.Lerp(player.position, targetPos, Time.deltaTime * launchSpeed);
                    }
                }
            }
        }
        else
        {
            grappleRope.enabled = false;
            m_springJoint2D.enabled = false;
            m_rigidbody.gravityScale = originalGravScale;

            RotateGun(controls.AimInput, true);
        }
         */
    }


    void RotateGun(Vector3 lookPoint, bool allowRotationOverTime)
    {
        Vector3 distanceVector = lookPoint - gunPivot.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if (rotateOverTime && allowRotationOverTime)
        {
            gunPivot.rotation = Quaternion.Lerp(gunPivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
        }
        else
        {
            gunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


    void SetGrapplePoint()
    {
        print("setting grapple point");

        // Vector2 distanceVector = m_camera.ScreenToWorldPoint(Input.mousePosition) - gunPivot.position;
        Vector2 distanceVector = m_camera.ScreenToWorldPoint(controls.AimInput) - gunPivot.position;

        if (Physics2D.Raycast(firePoint.position, distanceVector.normalized))
        {
            RaycastHit2D _hit = Physics2D.Raycast(firePoint.position, distanceVector.normalized);
            if (_hit.transform.gameObject.layer == grappableLayerNumber || grappleToAll)
            {
                if (Vector2.Distance(_hit.point, firePoint.position) <= maxDistnace || !hasMaxDistance)
                {
                    grapplePoint = _hit.point;
                    grappleDistanceVector = grapplePoint - (Vector2)gunPivot.position;
                    grappleRope.enabled = true;
                    // controls.UseTetherInput();
                }
            }
        }
        // controls.UseTetherInput();
    }

    public void Grapple()
    {
        print("grappling");
        m_springJoint2D.autoConfigureDistance = false;
        if (!launchToPoint && !autoConfigureDistance)
        {
            m_springJoint2D.distance = targetDistance;
            m_springJoint2D.frequency = targetFrequncy;
        }
        if (!launchToPoint)
        {
            if (autoConfigureDistance)
            {
                m_springJoint2D.autoConfigureDistance = true;
                m_springJoint2D.frequency = 0;
            }

            m_springJoint2D.connectedAnchor = grapplePoint;
            m_springJoint2D.enabled = true;
        }
        else
        {
            switch (launchType)
            {
                case LaunchType.Physics_Launch:
                    m_springJoint2D.connectedAnchor = grapplePoint;

                    // Vector2 distanceVector = firePoint.position - gunHolder.position;
                    Vector2 distanceVector = firePoint.position - player.position;

                    m_springJoint2D.distance = distanceVector.magnitude;
                    m_springJoint2D.frequency = launchSpeed;
                    m_springJoint2D.enabled = true;
                    break;
                case LaunchType.Transform_Launch:
                    m_rigidbody.gravityScale = 0;
                    m_rigidbody.velocity = Vector2.zero;
                    break;
            }
            // controls.UseTetherInput();
        }
    }

    // end of the road
}
