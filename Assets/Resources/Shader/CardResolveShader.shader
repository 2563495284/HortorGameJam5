Shader "Unlit/CardResolveShader"
{
    Properties
    {
        _MainTex ("MainTex", 2D) = "white" {}  // 主纹理
        _FadeMask ("Fade Mask", 2D) = "gray" {}  // 噪声纹理
        _EdgeColor ("EdgeColor", Color) = (0, 0.1, 1, 1)  // 边缘颜色
        _Speed ("Animation Speed", Float) = 1.0  // 动画速度
        _MainTex_UVRatio ("MainTex UV Ratio", Vector) = (1, 1, 0, 0)  // 主纹理UV比例
        _FadeMask_UVRatio ("FadeMask UV Ratio", Vector) = (1, 1, 0, 0)  // 噪声纹理UV比例
        _TimeDuration ("TimeDuration",float) = 1.0
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

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

            sampler2D _MainTex;
            sampler2D _FadeMask;
            float4 _MainTex_ST;

            float4 _EdgeColor;
            float _Speed;
            float _TimeDuration;

            // UV缩放比例
            float4 _MainTex_UVRatio;
            float4 _FadeMask_UVRatio;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;  // 保持原始UV坐标
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // 计算UV比例
                float2 mainUV = i.uv * _MainTex_UVRatio.xy;
                float2 maskUV = i.uv * _FadeMask_UVRatio.xy;

                // 主纹理颜色
                fixed4 clrA = tex2D(_MainTex, mainUV);

                // 淡化遮罩值
                float alphaValue = tex2D(_FadeMask, maskUV).r;

                // 时间驱动的溶解逻辑
                float t = (sin(_TimeDuration * _Speed) + 1.0) / 2.0;

                float edge_width_start = 0.15;
                float edge_width_end = 0.05;
                float edge_width = lerp(edge_width_start, edge_width_end, smoothstep(0.0, 1.0, t));

                float myAlpha = lerp(0.0 - edge_width, 1.0, t);

                // Alpha遮罩（一位）
                float a = step(alphaValue, myAlpha);
                // 边缘遮罩
                float edge = smoothstep(alphaValue - edge_width, alphaValue, myAlpha);

                float4 edgeColor = _EdgeColor * edge * 10.0*clrA.a;
                // 添加边缘颜色到主色
                clrA += edgeColor*0.03;

                // 在主纹理和背景纹理之间混合色彩
                float3 finalColor = clrA.rgb * a;
                float finalAlpha = clrA.a * a;

                return fixed4(finalColor, finalAlpha);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}