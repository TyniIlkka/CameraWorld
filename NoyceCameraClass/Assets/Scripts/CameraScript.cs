using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public CharacterController m_tPlayer;
    public float m_fDistanceToPlayer = 5f;
    public float m_fSpeed = 5f;
    public float m_fRotSpeed = 5f;


    public bool zooming;
    public float zoomSpeed;


    void Start()
    {
        // Sets Camera position to the player position at start
        transform.position = m_tPlayer.transform.position;
    }

    public void LateUpdate()
    {
        Vector3 newPos = m_tPlayer.transform.position - (m_tPlayer.transform.forward * m_fDistanceToPlayer);

        RaycastHit hit;
        if (Physics.SphereCast(m_tPlayer.transform.position , m_tPlayer.height / 2, -m_tPlayer.transform.forward, out hit, m_fDistanceToPlayer))
        {
            newPos = hit.point + m_tPlayer.transform.forward * 0.2f;
        }

        transform.position = Vector3.Slerp(transform.position, newPos, m_fSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, m_tPlayer.transform.rotation, m_fRotSpeed * Time.deltaTime);

    }
}
