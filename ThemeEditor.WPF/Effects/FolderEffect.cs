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

    public class FolderEffect : ShaderEffect
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
            = RegisterPixelShaderSamplerProperty(nameof(Input), typeof(FolderEffect), 0, SamplingMode.NearestNeighbor);

        public static readonly DependencyProperty ColorAProperty
             = RegisterPixelShaderConstantProperty(nameof(ColorA), typeof(FolderEffect), 0, Color.FromRgb(0, 0, 1)); // blue as default

        public static readonly DependencyProperty ColorBProperty
            = RegisterPixelShaderConstantProperty(nameof(ColorB), typeof(FolderEffect), 1, Color.FromRgb(0, 0, 1));

        public static readonly DependencyProperty ColorCProperty
            = RegisterPixelShaderConstantProperty(nameof(ColorC), typeof(FolderEffect), 2, Color.FromRgb(0, 0, 1));

        public static readonly DependencyProperty MidpointABProperty
            = RegisterPixelShaderConstantProperty(nameof(MidpointAB), typeof(FolderEffect), 3, 0.5f);

        public static readonly DependencyProperty MidpointBCProperty
            = RegisterPixelShaderConstantProperty(nameof(MidpointBC), typeof(FolderEffect), 4, 0.5f);

        public static readonly DependencyProperty CenterPointProperty
            = RegisterPixelShaderConstantProperty(nameof(CenterPoint), typeof(FolderEffect), 5, 0.5f);

        private static readonly PixelShader Shader = new PixelShader();

        #endregion

        #region Properties

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public Brush ColorA
        {
            get { return (Brush)GetValue(ColorAProperty); }
            set { SetValue(ColorAProperty, value); }
        }

        public Brush ColorB
        {
            get { return (Brush)GetValue(ColorBProperty); }
            set { SetValue(ColorBProperty, value); }
        }

        public Brush ColorC
        {
            get { return (Brush)GetValue(ColorCProperty); }
            set { SetValue(ColorCProperty, value); }
        }

        public float MidpointAB
        {
            get { return (float)GetValue(MidpointABProperty); }
            set { SetValue(MidpointABProperty, value); }
        }

        public float MidpointBC
        {
            get { return (float)GetValue(MidpointBCProperty); }
            set { SetValue(MidpointBCProperty, value); }
        }

        public float CenterPoint
        {
            get { return (float)GetValue(CenterPointProperty); }
            set { SetValue(CenterPointProperty, value); }
        }


        #endregion

        #region (De)Constructors

        static FolderEffect()
        {
            // Associate _pixelShader with our compiled pixel shader
            Shader.UriSource
                = new Uri(@"pack://application:,,,/ThemeEditor.WPF;component/Effects/FxBin/FolderEffect.ps");
        }

        public FolderEffect()
        {
            PixelShader = Shader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(ColorAProperty);
            UpdateShaderValue(ColorBProperty);
            UpdateShaderValue(ColorCProperty);
            UpdateShaderValue(MidpointABProperty);
            UpdateShaderValue(MidpointBCProperty);
            UpdateShaderValue(CenterPointProperty);

        }

        #endregion
    }
}