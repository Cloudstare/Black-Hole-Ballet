Shader "Custom/VignetteShader"
{
    Properties
    {
        _VignetteColor ("Vignette Color", Color) = (0,0,0,1)
        _VignetteIntensity ("Vignette Intensity", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _VignetteColor;
            float _VignetteIntensity;

            half4 frag(v2f_img i) : COLOR
            {
                half2 uv = i.uv - 0.5;
                float vignette = 1.0 - smoothstep(0.5 - _VignetteIntensity * 0.5, 0.5 + _VignetteIntensity * 0.5, dot(uv, uv));
                half4 color = tex2D(_MainTex, i.uv);
                color.rgb = lerp(color.rgb, _VignetteColor.rgb, 1.0 - vignette);
                return color;
            }
            ENDCG
        }
    }
}
