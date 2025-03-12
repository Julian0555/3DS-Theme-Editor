sampler2D Input : register(s0);

float4 Color : register(c0) = float4(0, 0, 0, 1); 

float4 main(float2 uv : TEXCOORD) : COLOR
{    
    float4 tex = tex2D(Input, uv);
    float3 recolor = lerp(Color, 1, tex.r) * tex.a;
    return float4(recolor, tex.a);
}
