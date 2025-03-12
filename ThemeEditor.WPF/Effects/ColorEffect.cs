// --------------------------------------------------
// 3DS Theme Editor - FolderEffect.cs
// --------------------------------------------------

#region Usings

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Effects;

#endregion

namespace ThemeEditor.WPF.Effects
{

    public class ColorEffect : ShaderEffect
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
            = RegisterPixelShaderSamplerProperty(nameof(Input), typeof(ColorEffect), 0, SamplingMode.NearestNeighbor);

        public static readonly DependencyProperty ColorProperty
             = RegisterPixelShaderConstantProperty(nameof(Color), typeof(ColorEffect), 0, System.Windows.Media.Color.FromRgb(1, 1, 1));

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

        static ColorEffect()
        {
            // Associate _pixelShader with our compiled pixel shader
            Shader.UriSource
                = new Uri(@"pack://application:,,,/ThemeEditor.WPF;component/Effects/FxBin/ColorEffect.ps");
        }

        public ColorEffect()
        {
            PixelShader = Shader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(ColorProperty);
        }

        #endregion
    }
}