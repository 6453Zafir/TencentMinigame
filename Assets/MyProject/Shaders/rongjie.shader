// created by jingyu， QQ群； 326774447
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:34314,y:32789,varname:node_4013,prsc:2|diff-6518-OUT,clip-580-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:33836,y:32889,ptovrint:False,ptlb:Main_Color,ptin:_Main_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:3390,x:33837,y:32667,ptovrint:False,ptlb:Main_texture,ptin:_Main_texture,varname:node_3390,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6ff16b062e86a5447857d1737250b16b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6518,x:34033,y:32780,varname:node_6518,prsc:2|A-3390-RGB,B-1304-RGB;n:type:ShaderForge.SFN_Tex2d,id:8021,x:33610,y:33170,varname:node_8021,prsc:2,tex:bc77d934a3f89494c916ba13273e801c,ntxv:0,isnm:False|UVIN-7229-UVOUT,TEX-8110-TEX;n:type:ShaderForge.SFN_TexCoord,id:3342,x:32032,y:33248,varname:node_3342,prsc:2,uv:1,uaff:False;n:type:ShaderForge.SFN_Append,id:8361,x:33022,y:33224,varname:node_8361,prsc:2|A-3342-U,B-683-OUT;n:type:ShaderForge.SFN_Add,id:683,x:32827,y:33283,varname:node_683,prsc:2|A-3342-V,B-8154-OUT;n:type:ShaderForge.SFN_Slider,id:8154,x:32460,y:33548,ptovrint:False,ptlb:Move,ptin:_Move,varname:node_8154,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3148141,max:1;n:type:ShaderForge.SFN_UVTile,id:118,x:33119,y:33743,varname:node_118,prsc:2|UVIN-8361-OUT,WDT-1159-OUT,HGT-865-OUT,TILE-3338-OUT;n:type:ShaderForge.SFN_Vector1,id:865,x:32935,y:33475,varname:node_865,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:1159,x:32978,y:33401,varname:node_1159,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:3338,x:33043,y:33558,varname:node_3338,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:1409,x:33851,y:33328,ptovrint:False,ptlb:Rongjie_Tex,ptin:_Rongjie_Tex,varname:node_1409,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6ff16b062e86a5447857d1737250b16b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:4049,x:33919,y:33139,varname:node_4049,prsc:2|A-8021-R,B-1409-R;n:type:ShaderForge.SFN_Tex2dAsset,id:8110,x:33530,y:33406,ptovrint:False,ptlb:Ramp_Tex,ptin:_Ramp_Tex,varname:node_8110,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bc77d934a3f89494c916ba13273e801c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2890,x:33613,y:33823,varname:node_2890,prsc:2,tex:bc77d934a3f89494c916ba13273e801c,ntxv:0,isnm:False|UVIN-7229-UVOUT,TEX-8110-TEX;n:type:ShaderForge.SFN_OneMinus,id:6946,x:33952,y:33791,varname:node_6946,prsc:2|IN-2890-R;n:type:ShaderForge.SFN_Subtract,id:580,x:34209,y:33560,varname:node_580,prsc:2|A-4049-OUT,B-6946-OUT;n:type:ShaderForge.SFN_Rotator,id:7229,x:33309,y:33905,varname:node_7229,prsc:2|UVIN-118-UVOUT,ANG-9850-OUT;n:type:ShaderForge.SFN_Slider,id:3820,x:32846,y:34175,ptovrint:False,ptlb:Rotate,ptin:_Rotate,varname:node_3820,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:360;n:type:ShaderForge.SFN_RemapRange,id:9850,x:33257,y:34189,varname:node_9850,prsc:2,frmn:0,frmx:360,tomn:0,tomx:6.265713|IN-3820-OUT;proporder:1304-3390-8154-1409-8110-3820;pass:END;sub:END;*/

Shader "Jingyu/Ramp_Rongjie" {
    Properties {
        _Main_Color ("Main_Color", Color) = (1,1,1,1)
        _Main_texture ("Main_texture", 2D) = "white" {}
        _Move ("Move", Range(0, 1)) = 0.3148141
        _Rongjie_Tex ("Rongjie_Tex", 2D) = "white" {}
        _Ramp_Tex ("Ramp_Tex", 2D) = "white" {}
        _Rotate ("Rotate", Range(0, 360)) = 0
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
            Cull Off
            
            
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
            uniform float4 _Main_Color;
            uniform sampler2D _Main_texture; uniform float4 _Main_texture_ST;
            uniform float _Move;
            uniform sampler2D _Rongjie_Tex; uniform float4 _Rongjie_Tex_ST;
            uniform sampler2D _Ramp_Tex; uniform float4 _Ramp_Tex_ST;
            uniform float _Rotate;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_7229_ang = (_Rotate*0.01740476+0.0);
                float node_7229_spd = 1.0;
                float node_7229_cos = cos(node_7229_spd*node_7229_ang);
                float node_7229_sin = sin(node_7229_spd*node_7229_ang);
                float2 node_7229_piv = float2(0.5,0.5);
                float node_1159 = 1.0;
                float node_3338 = 0.0;
                float2 node_118_tc_rcp = float2(1.0,1.0)/float2( node_1159, 2.0 );
                float node_118_ty = floor(node_3338 * node_118_tc_rcp.x);
                float node_118_tx = node_3338 - node_1159 * node_118_ty;
                float2 node_118 = (float2(i.uv1.r,(i.uv1.g+_Move)) + float2(node_118_tx, node_118_ty)) * node_118_tc_rcp;
                float2 node_7229 = (mul(node_118-node_7229_piv,float2x2( node_7229_cos, -node_7229_sin, node_7229_sin, node_7229_cos))+node_7229_piv);
                float4 node_8021 = tex2D(_Ramp_Tex,TRANSFORM_TEX(node_7229, _Ramp_Tex));
                float4 _Rongjie_Tex_var = tex2D(_Rongjie_Tex,TRANSFORM_TEX(i.uv0, _Rongjie_Tex));
                float4 node_2890 = tex2D(_Ramp_Tex,TRANSFORM_TEX(node_7229, _Ramp_Tex));
                clip(((node_8021.r+_Rongjie_Tex_var.r)-(1.0 - node_2890.r)) - 0.5);
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
                float4 _Main_texture_var = tex2D(_Main_texture,TRANSFORM_TEX(i.uv0, _Main_texture));
                float3 diffuseColor = (_Main_texture_var.rgb*_Main_Color.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Main_Color;
            uniform sampler2D _Main_texture; uniform float4 _Main_texture_ST;
            uniform float _Move;
            uniform sampler2D _Rongjie_Tex; uniform float4 _Rongjie_Tex_ST;
            uniform sampler2D _Ramp_Tex; uniform float4 _Ramp_Tex_ST;
            uniform float _Rotate;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_7229_ang = (_Rotate*0.01740476+0.0);
                float node_7229_spd = 1.0;
                float node_7229_cos = cos(node_7229_spd*node_7229_ang);
                float node_7229_sin = sin(node_7229_spd*node_7229_ang);
                float2 node_7229_piv = float2(0.5,0.5);
                float node_1159 = 1.0;
                float node_3338 = 0.0;
                float2 node_118_tc_rcp = float2(1.0,1.0)/float2( node_1159, 2.0 );
                float node_118_ty = floor(node_3338 * node_118_tc_rcp.x);
                float node_118_tx = node_3338 - node_1159 * node_118_ty;
                float2 node_118 = (float2(i.uv1.r,(i.uv1.g+_Move)) + float2(node_118_tx, node_118_ty)) * node_118_tc_rcp;
                float2 node_7229 = (mul(node_118-node_7229_piv,float2x2( node_7229_cos, -node_7229_sin, node_7229_sin, node_7229_cos))+node_7229_piv);
                float4 node_8021 = tex2D(_Ramp_Tex,TRANSFORM_TEX(node_7229, _Ramp_Tex));
                float4 _Rongjie_Tex_var = tex2D(_Rongjie_Tex,TRANSFORM_TEX(i.uv0, _Rongjie_Tex));
                float4 node_2890 = tex2D(_Ramp_Tex,TRANSFORM_TEX(node_7229, _Ramp_Tex));
                clip(((node_8021.r+_Rongjie_Tex_var.r)-(1.0 - node_2890.r)) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Main_texture_var = tex2D(_Main_texture,TRANSFORM_TEX(i.uv0, _Main_texture));
                float3 diffuseColor = (_Main_texture_var.rgb*_Main_Color.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
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
            uniform float _Move;
            uniform sampler2D _Rongjie_Tex; uniform float4 _Rongjie_Tex_ST;
            uniform sampler2D _Ramp_Tex; uniform float4 _Ramp_Tex_ST;
            uniform float _Rotate;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float node_7229_ang = (_Rotate*0.01740476+0.0);
                float node_7229_spd = 1.0;
                float node_7229_cos = cos(node_7229_spd*node_7229_ang);
                float node_7229_sin = sin(node_7229_spd*node_7229_ang);
                float2 node_7229_piv = float2(0.5,0.5);
                float node_1159 = 1.0;
                float node_3338 = 0.0;
                float2 node_118_tc_rcp = float2(1.0,1.0)/float2( node_1159, 2.0 );
                float node_118_ty = floor(node_3338 * node_118_tc_rcp.x);
                float node_118_tx = node_3338 - node_1159 * node_118_ty;
                float2 node_118 = (float2(i.uv1.r,(i.uv1.g+_Move)) + float2(node_118_tx, node_118_ty)) * node_118_tc_rcp;
                float2 node_7229 = (mul(node_118-node_7229_piv,float2x2( node_7229_cos, -node_7229_sin, node_7229_sin, node_7229_cos))+node_7229_piv);
                float4 node_8021 = tex2D(_Ramp_Tex,TRANSFORM_TEX(node_7229, _Ramp_Tex));
                float4 _Rongjie_Tex_var = tex2D(_Rongjie_Tex,TRANSFORM_TEX(i.uv0, _Rongjie_Tex));
                float4 node_2890 = tex2D(_Ramp_Tex,TRANSFORM_TEX(node_7229, _Ramp_Tex));
                clip(((node_8021.r+_Rongjie_Tex_var.r)-(1.0 - node_2890.r)) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
