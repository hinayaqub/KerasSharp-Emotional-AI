
Shader "COPPRA/OUTLINE1"
{
    Properties 
    {

		[MaterialToggle(_TEX_ON)] _DetailTex ("Enable Detail texture", Float) = 0 
		_MainTex ("Detail", 2D) = "white" {}        							
		_ToonShade ("Shade", 2D) = "white" {}  									
		[MaterialToggle(_COLOR_ON)] _TintColor ("Enable Color Tint", Float) = 0 
		_Color ("Base Color", Color) = (1,1,1,1)									
		[MaterialToggle(_VCOLOR_ON)] _VertexColor ("Enable Vertex Color", Float) = 0       
		_Brightness ("Brightness 1 = neutral", Float) = 1.0							
		_OutlineColor ("Outline Color", Color) = (0.5,0.5,0.5,1.0)				
		_Outline ("Outline width", Float) = 0.01							
    }
 
    SubShader
    {
        Tags { "RenderType"="Opaque" }
		LOD 250 
        Lighting Off
        Fog { Mode Off }
        
        UsePass "COPPRA/DEFAULT1/DEFAULT"
        	
        Pass
        {
            Cull Front
            ZWrite On
            CGPROGRAM
			#include "UnityCG.cginc"
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma glsl_no_auto_normalization
            #pragma vertex vert
 			#pragma fragment frag
			
            struct appdata_t 
            {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f 
			{
				float4 pos : SV_POSITION;
			};

            fixed _Outline;

            
            v2f vert (appdata_t v) 
            {
                v2f o;
			    o.pos = v.vertex;
			    o.pos.xyz += normalize(v.normal.xyz) *_Outline*0.01;
			    o.pos = UnityObjectToClipPos(o.pos);
			    return o;
            }
            
            fixed4 _OutlineColor;
            
            fixed4 frag(v2f i) :COLOR 
			{
		    	return _OutlineColor;
			}
            
            ENDCG
        }
    }
Fallback "Legacy Shaders/Diffuse"
}