// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:14,ufog:True,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|emission-1726-OUT,voffset-8299-OUT;n:type:ShaderForge.SFN_DepthBlend,id:5941,x:31378,y:32775,varname:node_5941,prsc:2|DIST-2226-OUT;n:type:ShaderForge.SFN_OneMinus,id:9461,x:31571,y:32775,varname:node_9461,prsc:2|IN-5941-OUT;n:type:ShaderForge.SFN_Lerp,id:3157,x:31859,y:32619,varname:node_3157,prsc:2|A-4848-RGB,B-5173-RGB,T-9461-OUT;n:type:ShaderForge.SFN_Color,id:4848,x:31193,y:32367,ptovrint:False,ptlb:WaterColor,ptin:_WaterColor,varname:node_4848,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.8758622,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:5173,x:31193,y:32536,ptovrint:False,ptlb:FoamColor,ptin:_FoamColor,varname:node_5173,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:2226,x:31190,y:32788,ptovrint:False,ptlb:ShoreLength,ptin:_ShoreLength,varname:node_2226,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.25;n:type:ShaderForge.SFN_Step,id:6662,x:31768,y:32905,varname:node_6662,prsc:2|A-9461-OUT,B-1649-OUT;n:type:ShaderForge.SFN_Vector1,id:1649,x:31245,y:32999,varname:node_1649,prsc:2,v1:0.9;n:type:ShaderForge.SFN_Sin,id:7871,x:31156,y:33367,varname:node_7871,prsc:2|IN-7454-OUT;n:type:ShaderForge.SFN_Time,id:5066,x:30705,y:33749,varname:node_5066,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:3730,x:31390,y:33367,varname:node_3730,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-7871-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6570,x:31390,y:33570,ptovrint:False,ptlb:WaveHeight,ptin:_WaveHeight,varname:node_6570,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.15;n:type:ShaderForge.SFN_Multiply,id:8299,x:31627,y:33367,varname:node_8299,prsc:2|A-3730-OUT,B-6570-OUT;n:type:ShaderForge.SFN_TexCoord,id:2398,x:30105,y:33371,varname:node_2398,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:8603,x:30340,y:33371,varname:node_8603,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-2398-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7454,x:30942,y:33367,varname:node_7454,prsc:2|A-1147-OUT,B-6050-OUT,C-3623-OUT;n:type:ShaderForge.SFN_Tau,id:6050,x:30753,y:33513,varname:node_6050,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:3623,x:30753,y:33652,ptovrint:False,ptlb:WaveFrequency,ptin:_WaveFrequency,varname:node_3623,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Time,id:501,x:30210,y:33673,varname:node_501,prsc:2;n:type:ShaderForge.SFN_Add,id:1147,x:30613,y:33371,varname:node_1147,prsc:2|A-8603-OUT,B-501-T;n:type:ShaderForge.SFN_Tex2d,id:5472,x:31551,y:33116,ptovrint:False,ptlb:Surface1,ptin:_Surface1,varname:node_5472,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4dd07b577d7622d4c8a4e523f0063d2d,ntxv:0,isnm:False|UVIN-3313-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7343,x:31061,y:33117,varname:node_7343,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:3313,x:31285,y:33117,varname:node_3313,prsc:2,spu:0.15,spv:0|UVIN-7343-UVOUT,DIST-6124-OUT;n:type:ShaderForge.SFN_Add,id:1726,x:32080,y:32997,varname:node_1726,prsc:2|A-3157-OUT,B-624-OUT;n:type:ShaderForge.SFN_Multiply,id:6124,x:31041,y:33671,varname:node_6124,prsc:2|A-3623-OUT,B-5066-T;n:type:ShaderForge.SFN_Tex2d,id:8766,x:31641,y:33681,ptovrint:False,ptlb:Surface2,ptin:_Surface2,varname:node_8766,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8349bbe14ea10db438259151870447a3,ntxv:0,isnm:False|UVIN-5594-UVOUT;n:type:ShaderForge.SFN_Panner,id:5594,x:31430,y:33681,varname:node_5594,prsc:2,spu:0,spv:0.15|UVIN-3745-UVOUT,DIST-6124-OUT;n:type:ShaderForge.SFN_TexCoord,id:3745,x:31235,y:33681,varname:node_3745,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:1289,x:31787,y:33180,varname:node_1289,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5472-RGB;n:type:ShaderForge.SFN_Multiply,id:624,x:31945,y:33180,varname:node_624,prsc:2|A-1289-OUT,B-8766-RGB;proporder:4848-5173-2226-6570-3623-5472-8766;pass:END;sub:END;*/

Shader "Shader Forge/StylizedWater" {
    Properties {
        _WaterColor ("WaterColor", Color) = (0,0.8758622,1,1)
        _FoamColor ("FoamColor", Color) = (1,1,1,1)
        _ShoreLength ("ShoreLength", Float ) = 0.25
        _WaveHeight ("WaveHeight", Float ) = 0.15
        _WaveFrequency ("WaveFrequency", Float ) = 0.5
        _Surface1 ("Surface1", 2D) = "white" {}
        _Surface2 ("Surface2", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            ColorMask RGB
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _WaterColor;
            uniform float4 _FoamColor;
            uniform float _ShoreLength;
            uniform float _WaveHeight;
            uniform float _WaveFrequency;
            uniform sampler2D _Surface1; uniform float4 _Surface1_ST;
            uniform sampler2D _Surface2; uniform float4 _Surface2_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 projPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_501 = _Time;
                float node_8299 = ((sin(((o.uv0.r+node_501.g)*6.28318530718*_WaveFrequency))*0.5+0.5)*_WaveHeight);
                v.vertex.xyz += float3(node_8299,node_8299,node_8299);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float node_9461 = (1.0 - saturate((sceneZ-partZ)/_ShoreLength));
                float4 node_5066 = _Time;
                float node_6124 = (_WaveFrequency*node_5066.g);
                float2 node_3313 = (i.uv0+node_6124*float2(0.15,0));
                float4 _Surface1_var = tex2D(_Surface1,TRANSFORM_TEX(node_3313, _Surface1));
                float2 node_5594 = (i.uv0+node_6124*float2(0,0.15));
                float4 _Surface2_var = tex2D(_Surface2,TRANSFORM_TEX(node_5594, _Surface2));
                float3 emissive = (lerp(_WaterColor.rgb,_FoamColor.rgb,node_9461)+(_Surface1_var.rgb.r*_Surface2_var.rgb));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            Cull Back
            ColorMask RGB
            
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
            uniform float _WaveHeight;
            uniform float _WaveFrequency;
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
                float4 node_501 = _Time;
                float node_8299 = ((sin(((o.uv0.r+node_501.g)*6.28318530718*_WaveFrequency))*0.5+0.5)*_WaveHeight);
                v.vertex.xyz += float3(node_8299,node_8299,node_8299);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
