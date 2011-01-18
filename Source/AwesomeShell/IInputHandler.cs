using System;

namespace AwesomeShell
{
	internal interface IInputHandler
	{
		bool Handle(ConsoleKeyInfo input, CommandEditor commandEditor);
	}
}