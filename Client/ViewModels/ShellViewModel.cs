namespace Subsonic8.ViewModels
{
    using Windows.UI.Xaml.Controls;
    using Caliburn.Micro;
    using Subsonic8.Messages;

    public class ShellViewModel : Screen, IHandle<ResumeStateMessage>, IHandle<SuspendStateMessage>
    {
        private readonly WinRTContainer _container;
        private readonly IEventAggregator _eventAggregator;
        private INavigationService _navigationService;
        private bool _resume;
        private bool _navigationPaneOpen;

        public bool NavigationPaneOpen
        {
            get { return _navigationPaneOpen; }
            set
            {
                if (value == _navigationPaneOpen)
                {
                    return;
                }

                _navigationPaneOpen = value;
                NotifyOfPropertyChange(() => NavigationPaneOpen);
            }
        }

        public ShellViewModel(WinRTContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            _eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            _eventAggregator.Unsubscribe(this);
        }

        public void SetupNavigationService(Frame frame)
        {
            _navigationService = _container.RegisterNavigationService(frame);
            if (_resume)
            {
                _navigationService.ResumeState();
            }
        }

        public void ShowHome()
        {
        }

        public void OpenNavigationPane()
        {
            NavigationPaneOpen = true;
        }

        public void Handle(SuspendStateMessage message)
        {
            _navigationService.SuspendState();
        }

        public void Handle(ResumeStateMessage message)
        {
            _resume = true;
        }
    }
}