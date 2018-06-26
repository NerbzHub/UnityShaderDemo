/*
	ShakeyImg.shader

	Purpose: To create an image effect that can be demonstrated
			via GUI interaction.
	
	@author Nathan Nette
*/
Shader "NathansShaders/ShakeyImg"
{
	Properties
	{
		// Texture to take in(Preferrably perlin noise tex)
		_MainTex ("Texture", 2D) = "white" {}
		// The Texture to displace the image from.
		_DisplaceTex("Displacement Texture", 2D) = "white"{}
		// How much the image is displaced.
		_Magnitude("Magnitude", Range(0.0,1.0)) = 1
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

		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		// Draw call
		Pass
		{
			CGPROGRAM
			//Vertex function called vert
			#pragma vertex vert
			//Fragment function called frag
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
				// Screen space position (SV needed for playstation)
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			// Always re-define all properties to pass them into the CG code.
			sampler2D _MainTex;
			sampler2D _DisplaceTex;
			float _Magnitude;

			fixed4 frag (v2f i) : SV_Target
			{
				// Create the displacement image in CG.
				float2 disp = tex2D(_DisplaceTex, i.uv).xy;
				disp = ((disp * 2) - 1) * _Magnitude;

				// Takes the MainTex, adds its uv + displacement.
				fixed4 col = tex2D(_MainTex, i.uv + disp);
				return col;
			}
			ENDCG
		}
	}
}
