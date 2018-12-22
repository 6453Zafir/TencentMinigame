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
    public static  bool can_draw_black;//是否用黑色画笔
    public static  bool is_draw_black;//是否作画
    protected List<Vector2> m_Points;

    private Vector2 buffer = Vector2.zero;
    private Vector2 now = Vector2.zero;
    private Vector2 end = Vector2.zero;
    private Vector2 V = Vector2.zero;
    private float limit = 10.0f;
    public GameObject m_line;
    //鼠标前后点的距离
    private float blackdistance;
    private float HadDrawDistance = 0.0f;
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
        can_draw_black = false;
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
            if (DelBlackLine_num == 0)
            {
                GameController.InkDistance += HadDrawDistance;
                HadDrawDistance = 0;
                
            }
            

        }
        if (HadDrawDistance >= limit)
        {
            can_draw_black = false;
            return;
        }
        

        if (Input.GetMouseButtonDown(0))
        { 
            if (can_draw_black) {
 
                is_draw_black = true;
            }
        }

        if (Input.GetMouseButtonUp(0)&&is_draw_black)
        {

            if (is_draw_black)
            {
                is_draw_black = false;
            }

            can_draw_black = false;
        }
        if (!can_draw_black) return;

        if (Input.GetMouseButtonDown(0) && GameController.InkDistance > 0)//判定是否是画的一条新线
        {         
            buffer = Vector2.zero;                //初始化上一画点
            now = Vector2.zero;                   //初始化现在画点
            m_Points = new List<Vector2>();       //初始化一条新线          
            GameController.BlackLine_num += 1;    //已画线条数加一
            m_line = new GameObject("BlackDraw");      //创建新的物体作为画线
            m_LineRenderer = m_line.AddComponent<LineRenderer>();
            m_EdgeCollider2D = m_line.AddComponent<EdgeCollider2D>();
            //Settings of the linerender component
            m_LineRenderer.positionCount = 0;       //Describe an array of Vector3 points to connect
            m_LineRenderer.material = m_material;      //Line material
            m_LineRenderer.startColor = Color.white;        //The color of startpoint
            m_LineRenderer.endColor = Color.white;         //The color of endpoint
            m_LineRenderer.startWidth = 0.4f; //The width of startpoint
            m_LineRenderer.endWidth = 0.4f;   //The width of endpoint
            m_LineRenderer.useWorldSpace = true;  //The points are considered as world space coordinates


        }
        else if (Input.GetMouseButton(0) && GameController.InkDistance > 0 )
        {
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
                //当剩余墨量大于需要画出的线段,并且不会超过850像素
                if (!m_Points.Contains(mousePosition) && (GameController.InkDistance - blackdistance) >= 0 && (blackdistance+HadDrawDistance)<limit)
                {
                    GameController.InkDistance = GameController.InkDistance - blackdistance;
                    HadDrawDistance += blackdistance;
                    m_Points.Add(mousePosition);
                    m_LineRenderer.positionCount = m_Points.Count;
                    m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, mousePosition);
                    if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                    {
                        m_EdgeCollider2D.points = m_Points.ToArray();
                    }
                }
                else if (!m_Points.Contains(mousePosition) && (GameController.InkDistance - blackdistance) >= 0 && (blackdistance + HadDrawDistance) >= limit)//墨水够，但是已超出850像素
                {
                    V = offset.normalized;
                    end = buffer + V * (limit-HadDrawDistance);
                    HadDrawDistance += (limit - HadDrawDistance);
                    Debug.Log(HadDrawDistance+"haddraw");
                    m_Points.Add(end);
                    m_LineRenderer.positionCount = m_Points.Count;
                    m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, end);
                    if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                    {
                        m_EdgeCollider2D.points = m_Points.ToArray();
                    }
                    GameController.InkDistance -= (limit - HadDrawDistance);
                }
                //当剩余墨量小于需要画出的线段
                else if (!m_Points.Contains(mousePosition) && (GameController.InkDistance - blackdistance) < 0)
                {
                   
                    float NowCanDraw = limit - HadDrawDistance;
                    if ( NowCanDraw > GameController.InkDistance)
                    {
                        Debug.Log("333");
                        V = offset.normalized;
                        end = buffer + V * GameController.InkDistance;
                        HadDrawDistance += GameController.InkDistance;
                        m_Points.Add(end);
                        m_LineRenderer.positionCount = m_Points.Count;
                        m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, end);
                        if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                        {
                            m_EdgeCollider2D.points = m_Points.ToArray();
                        }
                        GameController.InkDistance = 0;
                    }
                    else
                    {
                        Debug.Log("444");
                        V = offset.normalized;
                        end = buffer + V * NowCanDraw;
                        HadDrawDistance += NowCanDraw;
                        m_Points.Add(end);
                        m_LineRenderer.positionCount = m_Points.Count;
                        m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, end);
                        if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                        {
                            m_EdgeCollider2D.points = m_Points.ToArray();
                        }
                        GameController.InkDistance -= NowCanDraw;
                    }

                }
                
                buffer = now;

                
            }

        }


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
        m_LineRenderer.startWidth = 0.4f; //The width of startpoint
        m_LineRenderer.endWidth = 0.4f;   //The width of endpoint
        m_LineRenderer.useWorldSpace = true;  //The points are considered as world space coordinates
    }

    protected virtual void CreateDefaultEdgeCollider2D()
    {
        m_EdgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
    }


    public void ReGainBlackInk() {
        DelBlackLine_num = GameController.BlackLine_num;
        GameController.BlackLine_num = GameController.BlackLine_numzero;
    }
}
