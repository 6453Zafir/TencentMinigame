using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine2D : MonoBehaviour
{

	[SerializeField]
    public LineRenderer m_LineRenderer;
	[SerializeField]
	protected bool m_AddCollider = false;
	[SerializeField]
	protected EdgeCollider2D m_EdgeCollider2D;
	[SerializeField]
	protected Camera m_Camera;
	protected List<Vector2> m_Points;

    public virtual LineRenderer lineRenderer
	{
		get
		{
			return m_LineRenderer;
        }
        set
        {
            m_LineRenderer = value;
        }
	}

	public virtual bool addCollider
	{
		get
		{
			return m_AddCollider;
		}
	}

	public virtual EdgeCollider2D edgeCollider2D
	{
		get
		{
            return m_EdgeCollider2D;
		}
	}

	public virtual List<Vector2> points
	{
		get
		{
			return m_Points;
		}
	}

	//Debug info
	protected virtual void Awake ()
	{
		if ( m_LineRenderer == null )
		{
			//Line Render not assigned
			Debug.LogWarning ( "DrawLine: Line Renderer not assigned, Adding and Using default Line Renderer." );
			CreateDefaultLineRenderer ();
		}
		if ( m_EdgeCollider2D == null && m_AddCollider )
		{
			//Edge Collider 2D not assigned
			Debug.LogWarning ( "DrawLine: Edge Collider 2D not assigned, Adding and Using default Edge Collider 2D." );
			CreateDefaultEdgeCollider2D ();
		}
		if ( m_Camera == null ) {
			//Camera not assigned
			m_Camera = Camera.main;
		}
		m_Points = new List<Vector2> ();
	}

	//Get the mouseButtonDown position
	protected virtual void Update ()
	{
		if ( Input.GetMouseButtonDown ( 0 ) )
		{
			Reset ();
		}
		if ( Input.GetMouseButton ( 0 ) )
		{
			Vector2 mousePosition = m_Camera.ScreenToWorldPoint ( Input.mousePosition );
            if ( !m_Points.Contains ( mousePosition ) && GameController.InkNum>0)
			{
                GameController.InkNum -= 1;
				m_Points.Add ( mousePosition );
				m_LineRenderer.positionCount = m_Points.Count;
				m_LineRenderer.SetPosition ( m_LineRenderer.positionCount - 1, mousePosition );
				if ( m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1 )
				{
					m_EdgeCollider2D.points = m_Points.ToArray ();
				}
			}
		}
	}

	protected virtual void Reset ()
	{
		if ( m_LineRenderer != null )
		{
			m_LineRenderer.positionCount = 0;
		}
		if ( m_Points != null )
		{
			m_Points.Clear ();
		}
		if ( m_EdgeCollider2D != null && m_AddCollider )
		{
			m_EdgeCollider2D.Reset ();
		}
        GameController.InkNum = GameController.TotalInk;
	}

	protected virtual void CreateDefaultLineRenderer ()
	{
		//Add linerender component
		m_LineRenderer = gameObject.AddComponent<LineRenderer> ();
		//Settings of the linerender component
		m_LineRenderer.positionCount = 0;		//Describe an array of Vector3 points to connect
		m_LineRenderer.material = new Material ( Shader.Find ( "Particles/Additive" ) ); 		//Line material
		m_LineRenderer.startColor = Color.white;		//The color of startpoint
		m_LineRenderer.endColor = Color.white;		   //The color of endpoint
		m_LineRenderer.startWidth = 0.2f; //The width of startpoint
		m_LineRenderer.endWidth = 0.2f;   //The width of endpoint
		m_LineRenderer.useWorldSpace = true;  //The points are considered as world space coordinates
	}

	protected virtual void CreateDefaultEdgeCollider2D ()
	{
		m_EdgeCollider2D = gameObject.AddComponent<EdgeCollider2D> ();
	}
}
