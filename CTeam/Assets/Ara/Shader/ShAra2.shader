Shader "Custom/ShAra2"
{

    Properties
    {
        _MainTex("MainTex", 2D) = "white"{}


    }

        CGINCLUDE
        #include "UnityCG.cginc"

    float circle(float2 st)
    {

        return step(0.1, distance(0.5, st));
    }

    float4 frag(v2f_img i) : SV_Target
    {
        return circle(i.uv);
    }



        ENDCG

    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            ENDCG
        }
    }
}

