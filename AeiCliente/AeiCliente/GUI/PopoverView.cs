using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace AeiCliente
{
    public sealed class PopoverView : ContentControl
    {
        public PopoverView()
        {
            this.DefaultStyleKey = typeof(PopoverView);
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        /// <summary>
        /// Measure the size of this control: make it cover the full App window
        /// </summary>
        protected override Size MeasureOverride(Size availableSize)
        {
            Rect bounds = Window.Current.Bounds;
            availableSize = new Size(bounds.Width, bounds.Height);
            base.MeasureOverride(availableSize);
            return availableSize;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            InvalidateMeasure();
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= OnSizeChanged;
        }
    }
}
