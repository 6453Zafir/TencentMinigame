// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/XDDShader/ImageSequence"
{
	Properties
	{
        _Color("Color Tint",Color)=(1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
        _HorizentalAmount("Horizental Amount",float) = 4
        _VerticalAmount("Vertical Amount",float) = 4
        _Speed("Speed",Range(1,100))= 30
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
       
		Pass
		{
            Tags{"LightMode"="ForwardBase"}
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
           
			#pragma vertex vert
			#pragma fragment frag


			#include "UnityCG.cginc"

            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _HorizentalAmount;
            float _VerticalAmount;
            float _Speed;
			struct a2v
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 pos : SV_POSITION;
			};

			v2f vert (a2v v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float time = floor(_Time.y * _Speed);
                float row = floor(time/_HorizentalAmount);
                float column = time - row * _HorizentalAmount;
                half2 uv = i.uv+half2(column,-row);
                uv.x /= _HorizentalAmount;
                uv.y /= _VerticalAmount;
                fixed4 c = tex2D(_MainTex,uv);
                c.rgb *= _Color;
                return c;
			}
			ENDCG
		}
	}
    Fallback "Transparent/VertexLit"
}
