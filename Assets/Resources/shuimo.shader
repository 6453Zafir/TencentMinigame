// Made by jingyu ,qq qun;326774447
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:2,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33635,y:32685,varname:node_4013,prsc:2|diff-1304-RGB,clip-4542-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32443,y:32712,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:3557,x:32376,y:32929,varname:node_3557,prsc:2,tex:6961ba98c3be6244da618545f7e823f0,ntxv:0,isnm:False|TEX-9109-TEX;n:type:ShaderForge.SFN_OneMinus,id:828,x:32757,y:32963,varname:node_828,prsc:2|IN-3557-R;n:type:ShaderForge.SFN_Multiply,id:4542,x:33130,y:33231,varname:node_4542,prsc:2|A-828-OUT,B-9263-OUT,C-5914-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:9109,x:32187,y:33173,ptovrint:False,ptlb:mask,ptin:_mask,varname:node_9109,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6961ba98c3be6244da618545f7e823f0,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8810,x:32649,y:33335,varname:node_8810,prsc:2,tex:6961ba98c3be6244da618545f7e823f0,ntxv:0,isnm:False|UVIN-8769-OUT,TEX-9109-TEX;n:type:ShaderForge.SFN_TexCoord,id:5824,x:31925,y:33477,varname:node_5824,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_OneMinus,id:9263,x:32825,y:33350,varname:node_9263,prsc:2|IN-8810-R;n:type:ShaderForge.SFN_Append,id:8769,x:32502,y:33508,varname:node_8769,prsc:2|A-1228-OUT,B-5824-V;n:type:ShaderForge.SFN_Add,id:1228,x:32375,y:33360,varname:node_1228,prsc:2|A-5824-U,B-6486-OUT;n:type:ShaderForge.SFN_Slider,id:4835,x:31649,y:33727,ptovrint:False,ptlb:move,ptin:_move,varname:node_4835,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_OneMinus,id:6486,x:32181,y:33599,varname:node_6486,prsc:2|IN-4835-OUT;n:type:ShaderForge.SFN_Tex2d,id:1307,x:33226,y:33500,ptovrint:False,ptlb:rongjie_tex,ptin:_rongjie_tex,varname:node_1307,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:fa533503d7412114e8668fd26ffac25f,ntxv:0,isnm:False|UVIN-8769-OUT;n:type:ShaderForge.SFN_Add,id:5914,x:33534,y:33521,varname:node_5914,prsc:2|A-1307-R,B-2462-OUT;n:type:ShaderForge.SFN_Slider,id:2627,x:33069,y:33763,ptovrint:False,ptlb:rongjie,ptin:_rongjie,varname:node_2627,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:2462,x:33388,y:33718,varname:node_2462,prsc:2,frmn:0,frmx:1,tomn:1,tomx:-1|IN-2627-OUT;proporder:1304-9109-4835-1307-2627;pass:END;sub:END;*/

Shader "Jingyu/shuimo" {
    Properties {
        _Color ("Color", Color) = (0,0,0,1)
        _mask ("mask", 2D) = "white" {}
        _move ("move", Range(0, 1)) = 0
        _rongjie_tex ("rongjie_tex", 2D) = "white" {}
        _rongjie ("rongjie", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform float _move;
            uniform sampler2D _rongjie_tex; uniform float4 _rongjie_tex_ST;
            uniform float _rongjie;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 node_3557 = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                float2 node_8769 = float2((i.uv0.r+(1.0 - _move)),i.uv0.g);
                float4 node_8810 = tex2D(_mask,TRANSFORM_TEX(node_8769, _mask));
                float4 _rongjie_tex_var = tex2D(_rongjie_tex,TRANSFORM_TEX(node_8769, _rongjie_tex));
                clip(((1.0 - node_3557.r)*(1.0 - node_8810.r)*(_rongjie_tex_var.r+(_rongjie*-2.0+1.0))) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
       /* Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform float _move;
            uniform sampler2D _rongjie_tex; uniform float4 _rongjie_tex_ST;
            uniform float _rongjie;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_3557 = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                float2 node_8769 = float2((i.uv0.r+(1.0 - _move)),i.uv0.g);
                float4 node_8810 = tex2D(_mask,TRANSFORM_TEX(node_8769, _mask));
                float4 _rongjie_tex_var = tex2D(_rongjie_tex,TRANSFORM_TEX(node_8769, _rongjie_tex));
                clip(((1.0 - node_3557.r)*(1.0 - node_8810.r)*(_rongjie_tex_var.r+(_rongjie*-2.0+1.0))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }*/
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
