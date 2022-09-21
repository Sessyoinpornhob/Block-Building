Shader "Block-Building/buildings"
{
    //shader路径名
    Properties {
    }
    //材质面板参数
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 100
        
        Pass {
            Cull Off
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"        // 需要包含库文件是我没想到的
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            //以上暂时不管
            
            //输入结构：输入到顶点着色器中的结构
            struct VertexInput {
                float4 vertex : POSITION;     // 输入模型顶点信息
                float3 normal : NORMAL;       // 输入模型法线信息
            };
            
            //输出结构：从顶点着色器中输出的结构
            struct VertexOutput {
                float4 pos : SV_POSITION;     // 由模型顶点信息换算屏幕空间位置
                LIGHTING_COORDS(0,1)
            };
            
            //输入结构 > 顶点着色器 > 输出结构
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;              // 新建一个输出结构
                o.pos = UnityObjectToClipPos( v.vertex );      // 变换顶点信息 赋值给输出结构
                TRANSFER_VERTEX_TO_FRAGMENT(o);                // 奇妙的封装
                return o;                                      // 输出给输出结构
            }
            
            //输出结构 > 片元着色器/像素着色器
            float4 frag(VertexOutput i) : COLOR {
                float shadow = LIGHT_ATTENUATION(i);
                return float4(shadow, shadow, shadow, 1.0); // 转换为四维数
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
