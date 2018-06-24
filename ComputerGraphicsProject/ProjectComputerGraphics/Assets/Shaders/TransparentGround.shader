Shader "Unlit/TransparentGround"
{
	Properties
	{
		// Texture if wanted a texture
		_MainTex ("Texture", 2D) = "white" {}
		// Solid Colour to tint the tex by
		_TintColour("Tint Colour", Color) = (1,1,1,1)
		// Transparency value
		_Transparency("Transparency", Range(0.0,1.0)) = 1
	}
	SubShader
	{
			// There are many types of tags:
			// 
			// Background - skyboxes etc.
			// Geometry(Default) - Opaque on geometry
			// AlphaTest - alpha tested geometry uses this
			// Transparent - Don't write to depth buffer(Glass)
			// Overlay - Anything that is overlayed(UI, lens flares) 
			Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
			LOD 100

			// Not write to depth buffer
			ZWrite Off

			// blend them using the alpha channel
			Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _TintColour;
			float _Transparency;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv * _Transparency) + _TintColour;
				return col;
			}
			ENDCG
		}
	}
}
