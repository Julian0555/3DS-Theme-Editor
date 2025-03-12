sampler2D Input : register(s0);

float4 Bottom : register(c0) = float4(1, 1, 1, 1); 
float4 Top    : register(c1) = float4(0, 0, 0, 1);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 texColor = tex2D(Input, uv);
    float3 newColor = lerp(Top, Bottom, (uv.y * 0.6222) + 0.3765);
    return float4(newColor * texColor.a, texColor.a);
}
