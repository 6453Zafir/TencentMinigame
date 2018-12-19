using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBlueLine: MonoBehaviour
{
    public static Vector2 wind_start = Vector2.zero;//风的起始位置
    public static Vector2 wind_end = Vector2.zero;//风的结束位置
    //private float begin_time = 0.0f;
    //public static bool begin_count = false;
    private float duration = 5.0f;//持续时间
    public ParticleSystem m_particle;

    private Vector2 buffer = Vector2.zero;
    private Vector2 now = Vector2.zero;
    private bool stop_draw = false;

   
    private RaycastHit2D Hit;
    [SerializeField]
    public LineRenderer m_LineRenderer;
    [SerializeField]
    protected bool m_AddCollider = false;
    [SerializeField]
    protected EdgeCollider2D m_EdgeCollider2D;
    [SerializeField]
    protected Camera m_Camera;
    protected List<Vector2> m_Points;
    private Vector2 mouseposition = Vector2.zero;

    private bool stop = false;
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
    protected virtual void Awake()
    {
        buffer = Vector2.zero;
        now = Vector2.zero;
        m_particle.Stop();
        if (m_LineRenderer == null)
        {
            //Line Render not assigned
            Debug.LogWarning("DrawLine: Line Renderer not assigned, Adding and Using default Line Renderer.");
            CreateDefaultLineRenderer();
        }
        if (m_EdgeCollider2D == null && m_AddCollider)
        {
            //Edge Collider 2D not assigned
            Debug.LogWarning("DrawLine: Edge Collider 2D not assigned, Adding and Using default Edge Collider 2D.");
            CreateDefaultEdgeCollider2D();
        }

        if (m_Camera == null)
        {
            //Camera not assigned
            m_Camera = Camera.main;
        }
        m_Points = new List<Vector2>();
    }

    //Get the mouseButtonDown position
    protected virtual void Update()
    {

        //if ( !PlayerController.begin_count) return;

       
        if (PlayerController.wind_count && (Time.time- PlayerController.begin_time)>duration)
        {//风区持续时间到了
            PlayerController.wind_count = false;
            m_particle.Stop();
            Reset();
            return;
        }
        if(PlayerController.wind_count)
        {//计时时不允许画画
            return;
        }
        if (!PlayerController.can_draw_blue) return;

        if (Input.GetMouseButtonDown(0))//当鼠标按键按下时，返回一次true，后面参数0是左键，1是右键，2是中键		
        {
            
            Reset();
            //m_particle.Stop();
            wind_start = m_Camera.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            wind_end = m_Camera.ScreenToWorldPoint(Input.mousePosition);
           // m_particle.Play();
            m_particle.transform.position = wind_start;
        }
        if (Input.GetMouseButton(0))//当鼠标按键按下时，返回true，可能多次，根据你鼠标按下的时间	，后面参数0是左键，1是右键，2是中键	
        {
            
            if (buffer == Vector2.zero)
            {
                Vector2 mousePosition1 = m_Camera.ScreenToWorldPoint(Input.mousePosition);
                buffer = mousePosition1;
                return;
            }
            else
            {
                now = m_Camera.ScreenToWorldPoint(Input.mousePosition);
                m_EdgeCollider2D.enabled = false;
                if (Hit=Physics2D.Linecast(buffer, now))
                {
                    if(Hit.collider.tag!="Player" && Hit.collider.tag != "Boat")
                    {
                        stop = true;
                        Debug.Log(stop);
                    }                 
                }
                else
                {
                    if (!m_Points.Contains(now) && GameController.InkNum > 0 && stop == false )
                    {
                        
                        GameController.InkNum -= 1;
                        m_Points.Add(now);
                        m_LineRenderer.positionCount = m_Points.Count;
                        m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, now);
                        if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                        {
                            m_EdgeCollider2D.points = m_Points.ToArray();
                        }

                    }
                }
                m_EdgeCollider2D.enabled = true;
                buffer = now;
            }        
            }
            m_EdgeCollider2D.isTrigger =true;
        

    }


    protected virtual void Reset()
    {
        m_particle.Stop();
        wind_start = Vector2.zero;
        wind_end = Vector2.zero;
        buffer = Vector2.zero;
        now = Vector2.zero;
        

        stop = false;
        if (m_LineRenderer != null)
        {
            m_LineRenderer.positionCount = 0;
        }
        if (m_Points != null)
        {
            m_Points.Clear();
        }
        if (m_EdgeCollider2D != null && m_AddCollider)
        {
            m_EdgeCollider2D.Reset();
        }
        GameController.InkNum = GameController.TotalInk;
    }

    protected virtual void CreateDefaultLineRenderer()
    {
        //Add linerender component
        m_LineRenderer = gameObject.AddComponent<LineRenderer>();

        //Settings of the linerender component
        m_LineRenderer.positionCount = 0;       //Describe an array of Vector3 points to connect
        m_LineRenderer.material = new Material(Shader.Find("Particles/Additive"));      //Line material
        m_LineRenderer.startColor = Color.red;      //The color of startpoint
        m_LineRenderer.endColor = Color.red;           //The color of endpoint
        m_LineRenderer.startWidth = 0.2f; //The width of startpoint
        m_LineRenderer.endWidth = 0.2f;   //The width of endpoint
        m_LineRenderer.useWorldSpace = true;  //The points are considered as world space coordinates
    }

    protected virtual void CreateDefaultEdgeCollider2D()
    {
        m_EdgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
        m_EdgeCollider2D.isTrigger = true;
    }


}
