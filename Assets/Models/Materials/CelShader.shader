// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33335,y:32234,varname:node_4013,prsc:2|emission-5608-OUT;n:type:ShaderForge.SFN_NormalVector,id:5102,x:31265,y:32366,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:2567,x:31265,y:32205,varname:node_2567,prsc:2;n:type:ShaderForge.SFN_Step,id:9275,x:32034,y:32480,varname:node_9275,prsc:2|A-9149-OUT,B-4399-OUT;n:type:ShaderForge.SFN_Dot,id:4399,x:31467,y:32290,varname:node_4399,prsc:2,dt:0|A-2567-OUT,B-5102-OUT;n:type:ShaderForge.SFN_Slider,id:9149,x:31684,y:32525,ptovrint:False,ptlb:ShadowLength,ptin:_ShadowLength,varname:node_9149,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.4068593,max:1;n:type:ShaderForge.SFN_Slider,id:1432,x:31836,y:32967,ptovrint:False,ptlb:ShadowOpacity,ptin:_ShadowOpacity,varname:node_1432,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:1671,x:32333,y:32180,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_1671,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:5873,x:32227,y:32480,varname:node_5873,prsc:2|A-9275-OUT,B-1432-OUT;n:type:ShaderForge.SFN_Clamp01,id:4119,x:32376,y:32432,varname:node_4119,prsc:2|IN-5873-OUT;n:type:ShaderForge.SFN_Color,id:939,x:32243,y:33056,ptovrint:False,ptlb:ShadowColor,ptin:_ShadowColor,varname:node_939,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2058824,c2:0.2058824,c3:0.2058824,c4:1;n:type:ShaderForge.SFN_Lerp,id:1075,x:32581,y:32291,varname:node_1075,prsc:2|A-939-RGB,B-2734-OUT,T-4119-OUT;n:type:ShaderForge.SFN_Step,id:5757,x:32125,y:31826,varname:node_5757,prsc:2|A-9380-OUT,B-1242-OUT;n:type:ShaderForge.SFN_Slider,id:9380,x:31750,y:31716,ptovrint:False,ptlb:HighlightLength,ptin:_HighlightLength,varname:node_9380,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.2952151,max:1;n:type:ShaderForge.SFN_Slider,id:2465,x:31885,y:32038,ptovrint:False,ptlb:HighlightOpacity,ptin:_HighlightOpacity,varname:node_2465,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6735141,max:1;n:type:ShaderForge.SFN_Clamp01,id:25,x:32541,y:31826,varname:node_25,prsc:2|IN-5458-OUT;n:type:ShaderForge.SFN_Lerp,id:5608,x:32771,y:32004,varname:node_5608,prsc:2|A-1075-OUT,B-5271-RGB,T-25-OUT;n:type:ShaderForge.SFN_Color,id:5271,x:32574,y:31563,ptovrint:False,ptlb:HighlightColor,ptin:_HighlightColor,varname:node_5271,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Subtract,id:5458,x:32326,y:31826,varname:node_5458,prsc:2|A-5757-OUT,B-2465-OUT;n:type:ShaderForge.SFN_Color,id:2503,x:32326,y:32004,ptovrint:False,ptlb:Color Multiplier,ptin:_ColorMultiplier,varname:node_2503,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:2734,x:32545,y:32090,varname:node_2734,prsc:2|A-2503-RGB,B-1671-RGB;n:type:ShaderForge.SFN_Dot,id:1242,x:30766,y:31606,varname:node_1242,prsc:2,dt:0|A-9265-OUT,B-191-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:191,x:30430,y:31687,varname:node_191,prsc:2;n:type:ShaderForge.SFN_LightVector,id:9265,x:30363,y:31465,varname:node_9265,prsc:2;proporder:1671-2503-9149-1432-939-9380-2465-5271;pass:END;sub:END;*/

Shader "Shader Forge/CelShader" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _ColorMultiplier ("Color Multiplier", Color) = (1,1,1,1)
        _ShadowLength ("ShadowLength", Range(-1, 1)) = 0.4068593
        _ShadowOpacity ("ShadowOpacity", Range(0, 1)) = 0
        _ShadowColor ("ShadowColor", Color) = (0.2058824,0.2058824,0.2058824,1)
        _HighlightLength ("HighlightLength", Range(-1, 1)) = 0.2952151
        _HighlightOpacity ("HighlightOpacity", Range(0, 1)) = 0.6735141
        _HighlightColor ("HighlightColor", Color) = (1,1,1,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
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
            uniform float _ShadowLength;
            uniform float _ShadowOpacity;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _ShadowColor;
            uniform float _HighlightLength;
            uniform float _HighlightOpacity;
            uniform float4 _HighlightColor;
            uniform float4 _ColorMultiplier;
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
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_1242 = dot(lightDirection,viewReflectDirection);
                float3 emissive = lerp(lerp(_ShadowColor.rgb,(_ColorMultiplier.rgb*_MainTex_var.rgb),saturate((step(_ShadowLength,dot(lightDirection,i.normalDir))+_ShadowOpacity))),_HighlightColor.rgb,saturate((step(_HighlightLength,node_1242)-_HighlightOpacity)));
                float3 finalColor = emissive;
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
            uniform float _ShadowLength;
            uniform float _ShadowOpacity;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _ShadowColor;
            uniform float _HighlightLength;
            uniform float _HighlightOpacity;
            uniform float4 _HighlightColor;
            uniform float4 _ColorMultiplier;
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
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float3 finalColor = 0;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
