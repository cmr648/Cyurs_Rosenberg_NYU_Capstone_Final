// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/Pokemon_Shader"
{
	Properties
	{
		_MainTex ("Texture",2D) = "white" {}
		_TransitionTex("Transition Texture",2D) = "white" {}
		_Cutoff("Cutoff",range(0,1)) = 0 // creating the public reference for our cutoff
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

			float _Cutoff; // creating a float for our cutoff value
			fixed4 _Color; // creating a public reference to our color
			sampler2D _TransitionTex;


			fixed4 frag (v2f i) : SV_Target
			{


			fixed4 transit = tex2D(_TransitionTex,i.uv);

			if(transit.b < _Cutoff)
				return _Color;


			return tex2D(_MainTex,i.uv);

				
			
			

			}
			ENDCG
		}
	}
}
