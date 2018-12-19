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
    [SerializeField]

    protected List<Vector2> m_Points;
    protected List<List<Vector2>> pos;
    private Vector2 buffer = Vector2.zero;
    private Vector2 now = Vector2.zero;
    private Vector2 end = Vector2.zero;
    private Vector2 V = Vector2.zero;

    public GameObject m_line;
    //鼠标前后点的距离
    private float blackdistance;

    private int DelBlackLine_num = 0;

    public Material m_material;



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

    public virtual GameObject line
    {
        get
        {
            return m_line;
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
        pos = new List<List<Vector2>>();//对线的初始化
    }

    //Get the mouseButtonDown position
    protected virtual void Update()
    {

        //按Q键添加需要回收的黑色墨水
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DelBlackLine_num = GameController.BlackLine_num;
            GameController.BlackLine_num = GameController.BlackLine_numzero;

        }
        //若有需要回收的墨水则进行回收
        if (DelBlackLine_num != 0)
        {
            var draw = GameObject.Find("BlackDraw");
            Destroy(draw);
            DelBlackLine_num -= 1;
            GameController.BlackDistance = GameController.BlackTotalDistance;
        }

        if (Input.GetMouseButtonDown(0) && GameController.BlackDistance > 0)//判定是否是画的一条新线
        {
            if (!PlayerController.can_draw_black) return;
            buffer = Vector2.zero;                //初始化上一画点
            now = Vector2.zero;                   //初始化现在画点
            m_Points = new List<Vector2>();       //初始化一条新线
            pos.Add(m_Points);                    //添加到线的数组
            GameController.BlackLine_num += 1;    //已画线条数加一
            m_line = new GameObject("BlackDraw");      //创建新的物体作为画线
            m_LineRenderer = m_line.AddComponent<LineRenderer>();
            m_EdgeCollider2D = m_line.AddComponent<EdgeCollider2D>();
            //Settings of the linerender component
            m_LineRenderer.positionCount = 0;       //Describe an array of Vector3 points to connect
            m_LineRenderer.material = m_material;      //Line material
            m_LineRenderer.startColor = Color.white;        //The color of startpoint
            m_LineRenderer.endColor = Color.white;         //The color of endpoint
            m_LineRenderer.startWidth = 0.6f; //The width of startpoint
            m_LineRenderer.endWidth = 0.6f;   //The width of endpoint
            m_LineRenderer.useWorldSpace = true;  //The points are considered as world space coordinates


        }
        else if (Input.GetMouseButton(0) && GameController.BlackDistance > 0)
        {
            if (!PlayerController.can_draw_black) return;
            Vector2 mousePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);
            //如果刚开始画，对上一次鼠标位置做储存
            if (buffer == Vector2.zero)
            {
                Vector2 mousePosition1 = mousePosition;
                buffer = mousePosition1;
                return;
            }
            //对现在位置做储存
            else
            {
                now = mousePosition;
            }
            m_EdgeCollider2D.enabled = false;
            if (Physics2D.Linecast(buffer, now))
            {
                m_EdgeCollider2D.enabled = true;
                return;
            }
            m_EdgeCollider2D.enabled = true;
            if (now != Vector2.zero)
            {
                //计算两点之间距离
                Vector2 offset = now - buffer;
                blackdistance = offset.magnitude;
                //当剩余墨量大于需要画出的线段
                if (!m_Points.Contains(mousePosition) && (GameController.BlackDistance - blackdistance) >= 0)
                {


                    GameController.BlackDistance = GameController.BlackDistance - blackdistance;
                    m_Points.Add(mousePosition);
                    m_LineRenderer.positionCount = m_Points.Count;
                    m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, mousePosition);
                    if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                    {
                        m_EdgeCollider2D.points = m_Points.ToArray();
                    }
                }
                //当剩余墨量小于需要画出的线段
                else if (!m_Points.Contains(mousePosition) && (GameController.BlackDistance - blackdistance) < 0)
                {
                    V = offset.normalized;
                    end = buffer + V * GameController.BlackDistance;
                    m_Points.Add(end);
                    m_LineRenderer.positionCount = m_Points.Count;
                    m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, end);
                    if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                    {
                        m_EdgeCollider2D.points = m_Points.ToArray();
                    }
                    GameController.BlackDistance = 0;
                }
                buffer = now;

                //Debug.Log(GameController.BlackDistance);
            }

        }


    }

    protected virtual void Reset()
    {
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
        GameController.BlackDistance = GameController.BlackTotalDistance;
    }

    protected virtual void CreateDefaultLineRenderer()
    {
        //Add linerender component
        m_LineRenderer = gameObject.AddComponent<LineRenderer>();
        //Settings of the linerender component
        m_LineRenderer.positionCount = 0;       //Describe an array of Vector3 points to connect
        m_LineRenderer.material = m_material;      //Line material
        m_LineRenderer.startColor = Color.white;        //The color of startpoint
        m_LineRenderer.endColor = Color.white;         //The color of endpoint
        m_LineRenderer.startWidth = 0.6f; //The width of startpoint
        m_LineRenderer.endWidth = 0.6f;   //The width of endpoint
        m_LineRenderer.useWorldSpace = true;  //The points are considered as world space coordinates
    }

    protected virtual void CreateDefaultEdgeCollider2D()
    {
        m_EdgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
    }

}
