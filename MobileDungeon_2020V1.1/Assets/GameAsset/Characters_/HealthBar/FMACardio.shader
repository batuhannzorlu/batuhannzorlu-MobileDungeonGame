// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "AlchemistLab/UI/Cardio" {
	Properties {
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
	}
	SubShader {
			Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }

		Pass{
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Back
			ZWrite Off
            ZTest Off
			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color : COLOR;
				half2 texcoord  : TEXCOORD0;
			};
			sampler2D _MainTex;
			uniform float4 _MainTexKoef;
			fixed4 _TextureSampleAdd; //Added for font color support

			uniform sampler2D _MaskTex;
			float _Value;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				#ifdef UNITY_HALF_TEXEL_OFFSET
					OUT.vertex.xy += (_ScreenParams.zw - 1.0)*float2(-1,1);
				#endif
				OUT.color = IN.color;
				return OUT;
			}

			fixed4 frag(v2f input) : SV_Target
			{
				float x = input.texcoord.x / 2 + _Time * 5;
				x -= floor(x);
				x = x * 2 - 1;
				x = abs(x); 
				float4 c = tex2D(_MainTex, float2(x, input.texcoord.y)) * input.color;

				return c;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
