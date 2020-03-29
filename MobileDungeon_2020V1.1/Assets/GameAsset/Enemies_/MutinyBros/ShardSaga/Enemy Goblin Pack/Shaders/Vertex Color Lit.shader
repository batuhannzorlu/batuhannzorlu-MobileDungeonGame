Shader "Vertex Color Lit" {
	Properties {
		_MainTex("Texture", 2D) = "white" {}
	}
	CGINCLUDE
	 sampler2D _MainTex;
	ENDCG
	
	SubShader {
		Tags { "RenderType"="Opaque" }

		CGPROGRAM
		#pragma surface surf Lambert addshadow
		
		struct Input {
			float4 color : COLOR;
			float3 worldNormal;
			float2 uv_MainTex;
		};
	
		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = IN.color.rgb * tex2D (_MainTex, IN.uv_MainTex).rgb;
		}
		ENDCG
		

	
	
}
}