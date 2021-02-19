using System.Windows.Input;
using Xamarin.Forms;

namespace ToDo.Mobile.Behaviors
{
    public class ChangedEventWithParameterBehavior : Behavior<CheckBox>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(ChangedEventWithParameterBehavior), null);

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(ChangedEventWithParameterBehavior), null);

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, );
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
        }

        protected override void OnAttachedTo(CheckBox checkbox)
        {
            // checkbox.CheckedChanged += OnCheckChanged;

            base.OnAttachedTo(checkbox);
        }

        protected override void OnDetachingFrom(CheckBox checkbox)
        {
            //checkbox.CheckedChanged -= OnCheckChanged;

            base.OnDetachingFrom(checkbox);
        }

        private void OnCheckChanged(object sender, CheckedChangedEventArgs args)
        {
            //Command.Execute(CommandParameter);
        }
    }
}
