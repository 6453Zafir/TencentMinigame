using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBlueLine: MonoBehaviour
{
    
    public float duration =2.0f;//持续时间

    private float limit = 5.6f;//青色的线不能超过560像素

    public static bool can_draw_blue;//是否青画笔
    public static bool is_draw_blue;//是否作画
    private float begin_time;
    public ParticleSystem m_particle;
    public static List<Vector2> m_Points;//line的点
    private Vector2 mouseposition = Vector2.zero;
    private GameObject m_line;//line的gameobject
    public Material m_material;//线的材质
   
    private float bluedistance;//鼠标前后点的距离 
    private float HadDrawDistance = 0.0f;

    public static Vector2 wind_start = Vector2.zero;//风的起始位置
    public static Vector2 wind_end = Vector2.zero;//风的结束位置

    private Vector2 buffer = Vector2.zero;
    private Vector2 now = Vector2.zero;
    private RaycastHit2D Hit;
    [SerializeField]
    public LineRenderer m_LineRenderer;
    [SerializeField]
    protected bool m_AddCollider = false;
    [SerializeField]
    protected EdgeCollider2D m_EdgeCollider2D;
    [SerializeField]
    protected Camera m_Camera;



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

    public virtual GameObject line
    {
        get
        {
            return m_line;
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
        can_draw_blue = false;
        begin_time = 0.0f;
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


    protected virtual void Update()
    {            
        if (GameController.wind_count && (Time.time- begin_time)>duration)
        {//风区持续时间到了
            //Debug.Log(GameController.InkDistance);
            Debug.Log("风区持续时间到了"+ Time.time);
            BoatMove.begin_count = false;
            PlayerController.begin_count = false;
            DeleteLine();
            //Debug.Log(HadDrawDistance+"haddraw");
            return;
        }
        if (GameController.wind_count)
        {//计时时不允许画画
            return;
        }

        if (can_draw_blue)
        {
            if (Input.GetMouseButtonDown(0))
            {
                is_draw_blue = true;
            }
        }


        if (!can_draw_blue) return;

        if (Input.GetMouseButtonUp(0)&& is_draw_blue)
        {
            can_draw_blue = false;
            is_draw_blue = false;
            GameController.wind_count = true;//风生效
            begin_time = Time.time;//风生效的开始时间

            GameController.BlueLine_num += 1;     //已画线条数加一
            wind_end = m_Camera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (HadDrawDistance >= limit)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0) && GameController.InkDistance > 0)//当鼠标按键按下时，返回一次true，后面参数0是左键，1是右键，2是中键		
        {           
            if (GameController.BlueLine_num == 1)
            {      
                DeleteLine();
            }
            buffer = Vector2.zero;                //初始化上一画点
            now = Vector2.zero;                   //初始化现在画点
            m_Points = new List<Vector2>();       //初始化一条新线
            //pos.Add(m_Points);                    //添加到线的数组
           
            m_line = new GameObject("BlueDraw");      //创建新的物体作为画线
            m_line.tag = "Wind";
            /*****************************参数配置************************/
            /*-----------------------------------------------------------*/
            m_LineRenderer = m_line.AddComponent<LineRenderer>();
            m_EdgeCollider2D = m_line.AddComponent<EdgeCollider2D>();
            m_EdgeCollider2D.isTrigger = true;
            //Settings of the linerender component
            m_LineRenderer.positionCount = 0;       //Describe an array of Vector3 points to connect
            m_LineRenderer.material = m_material;      //Line material
            m_LineRenderer.startColor = Color.green;        //The color of startpoint
            m_LineRenderer.endColor = Color.green;         //The color of endpoint
            m_LineRenderer.startWidth = 0.5f; //The width of startpoint
            m_LineRenderer.endWidth = 0.5f;   //The width of endpoint
            m_LineRenderer.useWorldSpace = true;  //The points are considered as world space coordinates
            /*-----------------------------------------------------------*/
           
            wind_start = m_Camera.ScreenToWorldPoint(Input.mousePosition);
        }
        
        if (Input.GetMouseButton(0) && GameController.InkDistance > 0)//当鼠标按键按下时，返回true，可能多次，根据你鼠标按下的时间	，后面参数0是左键，1是右键，2是中键	
        {
            mouseposition = m_Camera.ScreenToWorldPoint(Input.mousePosition);
            if (buffer == Vector2.zero)
            {              
                Vector2 mousePosition1 = mouseposition;
                buffer = mousePosition1;
                return;
            }
            else
            {
                now = mouseposition;               
            }

            /****************射线检测需要关闭线自身的碰撞体*****************************/
            m_EdgeCollider2D.enabled = false;
            if (Hit = Physics2D.Linecast(buffer, now))
            {
                if (Hit.collider.tag != "Player" && Hit.collider.tag != "Boat" && Hit.collider.tag != "Fire")
                {
                    return;
                }
            }
            m_EdgeCollider2D.enabled = true;
           
            /****************射线检测完需要开启线自身的碰撞体*****************************/
            if (now != Vector2.zero)
            {                
                //计算两点之间距离
                Vector2 offset = now - buffer;
                bluedistance = offset.magnitude;
                //当剩余墨量大于需要画出的线段,并且不会超过560像素
                if (!m_Points.Contains(mouseposition) && (GameController.InkDistance - bluedistance) >= 0 && (bluedistance + HadDrawDistance) < limit)
                {

                    GameController.InkDistance = GameController.InkDistance - bluedistance;
                    HadDrawDistance += bluedistance;//已经画了bluedistances的长度
                    m_Points.Add(mouseposition);
                    m_LineRenderer.positionCount = m_Points.Count;
                    m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, mouseposition);
                    if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                    {
                        m_EdgeCollider2D.points = m_Points.ToArray();
                    }
   
                }
                else if (!m_Points.Contains(mouseposition) && (GameController.InkDistance - bluedistance) >= 0) //当剩余墨量大于需要画出的线段,并且超过560像素
                {

                    float NowCanDraw = limit - HadDrawDistance;
                    Vector2 v = offset.normalized;
                    Vector2 end = buffer + v * NowCanDraw;
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
                //当剩余墨量小于需要画出的线段
                else if (!m_Points.Contains(mouseposition) && (GameController.InkDistance - bluedistance) < 0)
                {
                     
                    float NowCanDraw = limit - HadDrawDistance;
                    if(NowCanDraw> GameController.InkDistance)
                    {

                        Vector2 v = offset.normalized;
                        Vector2 end = buffer + v * GameController.InkDistance;
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

                        Vector2 v = offset.normalized;
                        Vector2 end = buffer + v * NowCanDraw;
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
        m_LineRenderer.startColor = Color.green;      //The color of startpoint
        m_LineRenderer.endColor = Color.green;           //The color of endpoint
        m_LineRenderer.startWidth = 0.5f; //The width of startpoint
        m_LineRenderer.endWidth = 0.5f;   //The width of endpoint
        m_LineRenderer.useWorldSpace = true;  //The points are considered as world space coordinates
    }

    public void DeleteLine()
    {
        GameController.wind_count = false;
        GameController.forceReady = false;
        int DelBlueLine_num = GameController.BlueLine_num;
        GameController.BlueLine_num = GameController.BlueLine_numzero;
        //若有需要回收的墨水则进行回收
        if (DelBlueLine_num != 0)
        {

            var draw = GameObject.Find("BlueDraw");
            //Debug.Log("delete line" + draw);
            Destroy(draw);
            DelBlueLine_num -= 1;
            GameController.InkDistance += HadDrawDistance;
            if (GameController.InkDistance > 30) GameController.InkDistance = 30.0f;
             HadDrawDistance = 0;
        }
       
    }
    protected virtual void CreateDefaultEdgeCollider2D()
    {
        m_EdgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
        m_EdgeCollider2D.isTrigger = true;
    }


}
