﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CLAP
{
    internal static class EnvironmentParserHandlers
    {
        internal static MultiParser Console(this MultiParser parser)
        {
            parser.Register.HelpHandler("help,h,?", help => System.Console.WriteLine(help));
            parser.Register.ParameterHandler("debug", () => Debugger.Launch());
            parser.Register.ErrorHandler(c => System.Console.Error.WriteLine(c.Exception.Message));

            // a multi parser needs an empty help handler
            //
            if (parser.Types.Length > 1)
            {
                parser.Register.EmptyHelpHandler(help => System.Console.WriteLine(help));
            }

            return parser;
        }

        internal static MultiParser WinForms(this MultiParser parser)
        {
            parser.Register.HelpHandler("help,h,?", help => MessageBox.Show(help));
            parser.Register.ParameterHandler("debug", () => Debugger.Launch());
            parser.Register.ErrorHandler(c => MessageBox.Show(c.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));

            return parser;
        }
    }
}