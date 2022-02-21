using System;

namespace Carfup.XTBPlugins.AppCode
{
    public class BpfFieldControlActionEventArgs : EventArgs
    {
        public BpfFieldControlActionEventArgs(BpfFieldControlAction action)
        {
            Action = action;
        }

        public BpfFieldControlAction Action { get; }
    }
}