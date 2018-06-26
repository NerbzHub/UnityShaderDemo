/*
	TransparentGround.shader

		Purpose: To create a shader that can take in a texture,
				add transparency, add a colour tint.
				The reason I wanted this shader was so that I could
				place the procedurally generated terrain UNDER the
				main ground plane. This meant I needed to be able to 
				see through the ground. So I created this shader.

	@author Nathan Nette
*/
Shader "NathansShaders/TransparentGround"
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
			float4 _TintColour;
			float _Transparency;
			
			v2f vert (appdata v)
			{
				// what we're going to pass out of the vert func into
				// the frag (v2f is Vert to Frag).
				v2f o;
				// Used to be mul but now unity made this function.
				o.vertex = UnityObjectToClipPos(v.vertex);
				// Applying the texture to the object's UV coords
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}

			// Frag shader is working with potential pixels.

			// Takes in v2f (SV target is a render target)
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				// tex2D reads in the texture's colours and the object's UVs
				// * transparency then add the tint colour.
				fixed4 col = tex2D(_MainTex, i.uv * _Transparency) + _TintColour;
				return col;
			}
			ENDCG
		}
	}
}
