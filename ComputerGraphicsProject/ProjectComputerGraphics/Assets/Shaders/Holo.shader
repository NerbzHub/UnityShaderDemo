Shader "Unlit/Holo"
{
	Properties
	{
		// Main Texture applied to the mesh
		_MainTex ("Albedo Texture", 2D) = "white" {}
		// A colour to tint the texture by(using addition)
		_TintColor("Tint Colour", Color) = (1,1,1,1)
		// Creating a slider to change how transparent the object is
		_Transparency("Transparency", Range(0.0,0.5)) = 0.25
		// The threshold before it begins to cut out a colour from an image. 
		_CutoutThreshold("Cutout Threshold", Range(0.0,1.0)) = 0.2
		// Distance of vertices movement
		_Distance("Distance", float) = 1
		// How much they move
		_Amplitute("Amplitude", float) = 1
		//How fast they move
		_Speed ("Speed", float) = 1
		// 
		_Amount("Amount", Range(0.0,1.0)) = 1

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
		Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
		LOD 100
			
			// Not write to depth buffer
			ZWrite Off

			// blend them using the alpha channel
			Blend SrcAlpha OneMinusSrcAlpha

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

			// Any data from the editor needs to be re-created here 
			// inside the actual CG code so that it can access it.
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _TintColor;
			float _Transparency;
			float _CutoutThreshold;
			float _Distance;
			float _Amplitude;
			float _Speed;
			float _Amount;
			
			v2f vert (appdata v)
			{
				// what we're going to pass out of the vert func into
				// the frag (v2f is Vert to Frag)
				v2f o;
				//Time.y is the same as time.time which is in seconds
				v.vertex.x += sin(_Time.y  * _Speed + v.vertex.y * _Amplitude) * _Distance * _Amount;
				// Used to be mul but now unity made this function
				o.vertex = UnityObjectToClipPos(v.vertex);
				// Applying the texture to the object's UV coords
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			// Frag shader is working with potential pixels.

			// Takes in v2f (SV target is a render target)
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture col = colour
				// tex2D reads in the texture's colours and the object's UVs
				fixed4 col = tex2D(_MainTex, i.uv) + _TintColor;
				// Set the alpha to the transparent amount
				col.a = _Transparency;
				// discard certain pixel data
				// if col.r is a certain value and if it isn't, discard it
				clip(col.b - _CutoutThreshold);
				return col;
			}
			ENDCG
		}
	}
}
