sampler2D Input : register(s0);
/*{
    Filter = MIN_MAG_MIP_POINT; // Disables filtering (point sampling)
    MipFilter = None;
    AddressU = CLAMP;
    AddressV = CLAMP;
}*/

float4 ColorA : register(c0) = float4(0, 0, 1, 1); // Blue
float4 ColorB : register(c1) = float4(0, 1, 0, 1); // Green
float4 ColorC : register(c2) = float4(1, 0, 0, 1); // Red
float MidpointAB : register(c3) = 0.1272;
float MidpointBC : register(c4) = 0.3181815;
float CenterPoint : register(c5) = 0.5; // New adjustable center point

float4 main(float2 uv : TEXCOORD) : COLOR
{
    //float Gamma = 1;
    // Fetch texture color
    float4 texColor = tex2D(Input, uv);
    
    if (texColor.a < 0.01)
        return float4(0, 0, 0, 0);
    
    // Convert input to grayscale
    float greyscale = texColor.r / texColor.a;
    
    // Apply gamma correction
    /*float3 linearA = pow(ColorA.rgb, Gamma);
    float3 linearB = pow(ColorB.rgb, Gamma);
    float3 linearC = pow(ColorC.rgb, Gamma);*/
    
    float t;
    float3 result;
    if (greyscale < CenterPoint)
    {
        t = greyscale / CenterPoint;
        t = pow(t, log(0.5) / log(MidpointAB));
        result = lerp(ColorA.rgb, ColorB.rgb, t);
    }
    else
    {
        t = (greyscale - CenterPoint) / (1.0 - CenterPoint);
        t = pow(t, log(0.5) / log(1.0 - MidpointBC));
        result = lerp(ColorB.rgb, ColorC.rgb, t);
    }
    result *= texColor.a;
    return float4(result, texColor.a);
}
