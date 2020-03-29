Shader "Vertex Color Alpha" {
 
Properties {
    _MainTex ("Texture", 2D) = "white" {}
}
 
Category {

    Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
    Blend SrcAlpha OneMinusSrcAlpha
    Zwrite off
    Lighting Off
    BindChannels {
        Bind "Color", color
        Bind "Vertex", vertex
        Bind "TexCoord", texcoord
    }
 
    SubShader {
        Pass {
            SetTexture [_MainTex] {
                Combine texture * primary
            }
        }
    }
}
}