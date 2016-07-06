namespace Common.Behaviors
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Microsoft.Xaml.Interactivity;

    public class UnsnapBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += AssociatedObjectOnClick;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Click -= AssociatedObjectOnClick;
        }

        private static void AssociatedObjectOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            //ToDo replace this behavior with a maximize behavior
            Windows.UI.ViewManagement.ApplicationView.TryUnsnap();
        }
    }
}