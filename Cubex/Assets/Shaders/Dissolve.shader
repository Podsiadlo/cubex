// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Dissolve"
{
    // Declarations of shader properties visible in Inspector
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Threshold("Threshold", Float) = 0.0
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            // Vertex shader input
            struct appdata
            {
                float4 vertex : POSITION;  // mesh vertex position
                float2 uv : TEXCOORD0;     // texture coordinates
            };

            // Pixel shader input
            struct v2f
            {
                float4 vertex : SV_POSITION; // transformed vertex position
                float2 uv : TEXCOORD0;       // texture coordinates
            };

            // Variable declarations
            sampler2D _MainTex;
            float _Threshold;
            
            // Vertex shader
            v2f vert (appdata v)
            {
                v2f o;

                // multiply by model(world) / view / projection matrices
                // to transform from mesh position to clip space 
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            // Pixel shader
            fixed4 frag (v2f i) : SV_Target
            {
                // sample main texture, get R channel value
                float red = tex2D(_MainTex, i.uv).r;

                // if the value is smaller than threshold, discard 
                if(red < _Threshold)
                {
                    discard;
                }

                // return difference between threshold and red channel
                // (the closer to disappearing, the darker the color)
                return red - _Threshold;
            }
            ENDCG
        }
    }
}