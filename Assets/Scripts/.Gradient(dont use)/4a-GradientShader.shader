// I see. If you're only seeing the main camera's background color, it suggests that our gradient sprite is either not rendering or is being rendered behind the camera's clear color. Let's try a different approach using a full-screen quad with a shader. This method should work regardless of the camera setup.
// Unity Gradient ShaderClick to open code
// Now, let's create a script to use this shader:
// Unity Gradient ManagerClick to open code
// To use this new approach:

// Create a new shader in your project:

// Right-click in the Project window
// Select Create > Shader > Unlit Shader
// Name it "GradientBackground"
// Replace its contents with the shader code from the first artifact


// Create a new script named "GradientManager" and paste the C# code from the second artifact.
// In your scene:

// Select your Main Camera
// Add the GradientManager script to it
// Adjust the colors and heights in the inspector as needed



// This method uses a full-screen shader that renders behind everything else in your scene. It should work regardless of your camera setup or rendering pipeline.
// If you still don't see the gradient:

// Check the Console for any error messages.
// Make sure the shader compiled successfully (no errors in the shader asset).
// Verify that the Main Camera has the GradientManager script attached and enabled.
// Try adjusting the Sky Height and Space Height values in the inspector to see if that affects the gradient.

// Let me know if this works or if you need any further assistance!
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