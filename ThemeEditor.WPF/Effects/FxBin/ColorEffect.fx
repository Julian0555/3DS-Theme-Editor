sampler2D Input : register(s0);

float4 Color : register(c0) = float4(1, 1, 1, 1); 

float4 main(float2 uv : TEXCOORD) : COLOR
{
    /*float4 tex = tex2D(Input, uv);
    return float4(((tex.rgb / tex.a) * Color.rgb) * tex.a, tex.a);*/
    return tex2D(Input, uv) * Color;
}