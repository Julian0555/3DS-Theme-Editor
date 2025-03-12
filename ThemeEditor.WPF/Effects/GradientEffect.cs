// --------------------------------------------------
// 3DS Theme Editor - GradientEffect.cs
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

    public class GradientEffect : ShaderEffect
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
            = RegisterPixelShaderSamplerProperty(nameof(Input), typeof(GradientEffect), 0, SamplingMode.NearestNeighbor);

        public static readonly DependencyProperty BottomProperty
             = RegisterPixelShaderConstantProperty(nameof(Bottom), typeof(GradientEffect), 0, Color.FromRgb(1, 1, 1));

        public static readonly DependencyProperty TopProperty
             = RegisterPixelShaderConstantProperty(nameof(Top), typeof(GradientEffect), 1, Color.FromRgb(0, 0, 0));

        private static readonly PixelShader Shader = new PixelShader();

        #endregion

        #region Properties

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public Brush Bottom
        {
            get { return (Brush)GetValue(BottomProperty); }
            set { SetValue(BottomProperty, value); }
        }

        public Brush Top
        {
            get { return (Brush)GetValue(TopProperty); }
            set { SetValue(TopProperty, value); }
        }

        #endregion

        #region (De)Constructors

        static GradientEffect()
        {
            // Associate _pixelShader with our compiled pixel shader
            Shader.UriSource
                = new Uri(@"pack://application:,,,/ThemeEditor.WPF;component/Effects/FxBin/GradientEffect.ps");
        }

        public GradientEffect()
        {
            PixelShader = Shader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(BottomProperty);
            UpdateShaderValue(TopProperty);
        }

        #endregion
    }
}