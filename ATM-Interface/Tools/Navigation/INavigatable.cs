﻿using System;

namespace ATM_Interface.Tools.Navigation
{
    internal interface INavigatable
    {
        void KeyPadClick(String keyCode);

        bool CardDisplay();

        void Init(String arg = "");
    }
}
