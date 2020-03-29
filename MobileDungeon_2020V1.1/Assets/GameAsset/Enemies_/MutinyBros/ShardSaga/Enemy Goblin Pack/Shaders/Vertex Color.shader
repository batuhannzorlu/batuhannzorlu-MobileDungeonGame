Shader "Vertex Color" {
Properties {
    _MainTex ("Texture", 2D) = "white" {}
}
 
Category {
    Tags { "Queue"="Geometry" }
    Lighting Off
    Zwrite On
    Ztest On
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