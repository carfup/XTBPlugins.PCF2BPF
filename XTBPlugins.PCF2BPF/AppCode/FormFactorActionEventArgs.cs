using System;

namespace Carfup.XTBPlugins.AppCode
{
    public class FormFactorActionEventArgs : EventArgs
    {
        public FormFactorActionEventArgs(FormFactorAction action, FormFactor formFactor)
        {
            Action = action;
            FormFactor = formFactor;
        }

        public FormFactorAction Action { get; }
        public FormFactor FormFactor { get; }

    }
}