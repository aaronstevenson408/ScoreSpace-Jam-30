Shader "Custom/GradientBackground"
{
    Properties
    {
        _GroundColor ("Ground Color", Color) = (0.5,0.35,0.2,1)
        _SkyColor ("Sky Color", Color) = (0,0,1,1)
        _SpaceColor ("Space Color", Color) = (0,0,0,1)
        _SkyHeight ("Sky Height", Float) = 10
        _SpaceHeight ("Space Height", Float) = 20
    }
    SubShader
    {
        Tags {"Queue"="Background" "RenderType"="Background"}
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert alpha

        fixed4 _GroundColor;
        fixed4 _SkyColor;
        fixed4 _SpaceColor;
        float _SkyHeight;
        float _SpaceHeight;

        struct Input
        {
            float4 screenPos;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
            float y = screenUV.y * _SpaceHeight;

            fixed4 c;
            if (y < _SkyHeight)
            {
                c = lerp(_GroundColor, _SkyColor, y / _SkyHeight);
            }
            else
            {
                c = lerp(_SkyColor, _SpaceColor, (y - _SkyHeight) / (_SpaceHeight - _SkyHeight));
            }

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}