// --------------------------------------------------
// 3DS Theme Editor - RecolorEffect.cs
// --------------------------------------------------

#region Usings

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

#endregion

namespace ThemeEditor.WPF.Effects
{

    public class RecolorEffect : ShaderEffect
    {
        public static DependencyProperty RegisterPixelShaderConstantProperty<T>(string dpName, Type ownerType, int constantRegisterIndex, T defaultValue)
        {
            return DependencyProperty.Register(dpName,
                typeof(T),
                ownerType,
                new UIPropertyMetadata(defaultValue, PixelShaderConstantCallback(constantRegisterIndex)));
        }



        #region Fields

        public static readonly DependencyProperty InputProperty
            = RegisterPixelShaderSamplerProperty(nameof(Input), typeof(RecolorEffect), 0, SamplingMode.NearestNeighbor);

        public static readonly DependencyProperty ColorProperty
             = RegisterPixelShaderConstantProperty(nameof(Color), typeof(RecolorEffect), 0, System.Windows.Media.Color.FromRgb(0, 0, 0));

        private static readonly PixelShader Shader = new PixelShader();

        #endregion

        #region Properties

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        #endregion

        #region (De)Constructors

        static RecolorEffect()
        {
            // Associate _pixelShader with our compiled pixel shader
            Shader.UriSource
                = new Uri(@"pack://application:,,,/ThemeEditor.WPF;component/Effects/FxBin/RecolorEffect.ps");
        }

        public RecolorEffect()
        {
            PixelShader = Shader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(ColorProperty);
        }

        #endregion
    }
}