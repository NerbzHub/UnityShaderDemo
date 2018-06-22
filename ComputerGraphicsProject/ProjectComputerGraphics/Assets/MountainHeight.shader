// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/NathansShaders/MountainHeight"
{
	Properties
	{
		//White->Brown->Green
		_PeakColour("Peak Colour") = 1,1,1,1
		_MountainColour("Mountain Colour") = (139, 69, 19)
	//_GrassColour("Grass Colour") = (71,33,0)
		_GradientBlend("Gradient Blend", float) = 1
	}

		SubShader
	{

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 worldPosition : TEXCOORD0;
			};

			float4 _PeakColour;
			float4 _MountainColour;
			float4 _GrassColour;
			float _GradientBlend;

			v2f vert(appdata v)
			{
				v2f o;
				o.position = UnityObjectToClipPos(v.vertex);
				o.worldPosition = mul(unity_ObjectToWorld, v.vertex).xyz;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float4 gradientColour = lerp(_MountainColour, _PeakColour, v.worldPosition * _GradientBlend);

				return gradientColour;
			}
			ENDCG
		}
	}
		FallBack "Diffuse"
}
