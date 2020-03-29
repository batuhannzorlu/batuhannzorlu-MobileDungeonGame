// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "AlchemistLab/UI/HealthBar" {
	Properties {
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_MainTexKoef("Screen koef", Vector) = (0, 0, 1, 1)
		_MaskTex("Mask texture", 2D) = "gray" {}		
		_Value("Value", Range (0, 1)) = 1
		_BublesTex("Bubbles Texture", 2D) = "black" {}
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
			uniform sampler2D _BublesTex;
			float4 _BublesTex_ST;
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
				float4 c = tex2D(_MainTex, input.texcoord) * input.color;
				float maskValue = (tex2D(_MaskTex, input.texcoord - float2(0.015, 0)).r + tex2D(_MaskTex, input.texcoord).r + tex2D(_MaskTex, input.texcoord + float2(0.015, 0)).r) / 3;
				c.a *= smoothstep((1 - _Value) - 0.01, (1 - _Value) + 0.01, maskValue);
				float ydelta = -_Time * 5;
				float xdelta = sin(_Time * 30 + input.texcoord.x) / 10;
				float2 bubleUV = TRANSFORM_TEX(input.texcoord, _BublesTex) + float2(xdelta, ydelta);
				c.rgb *= 1 + max(sin(input.texcoord.y), 0) * tex2D(_BublesTex, bubleUV).r;
				return c;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
