namespace Wpf.Template.Controls.Navigation.Common;

public enum TransitionType
{
    /// <summary>
    /// None.
    /// </summary>
    None,

    /// <summary>
    /// Change opacity.
    /// </summary>
    FadeIn,

    /// <summary>
    /// Change opacity and slide from bottom.
    /// </summary>
    FadeInWithSlide,

    /// <summary>
    /// Slide from bottom.
    /// </summary>
    SlideBottom,

    /// <summary>
    /// Slide from the right side.
    /// </summary>
    SlideRight,

    /// <summary>
    /// Slide from the left side.
    /// </summary>
    SlideLeft,
}
