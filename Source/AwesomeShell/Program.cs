using System;
using System.Collections.Generic;
using AwesomeShell.InputHandlers;

namespace AwesomeShell
{
	internal static class Program
	{
		private static readonly IEnumerable<IInputHandler> inputHandlers = new IInputHandler[]
		{
			new PrintableCharacterHandler(),
			new LeftArrowHandler(),
			new RightArrowHandler(),
			new HomeHandler(),
			new EndHandler(),
			new BackspaceHandler(),
			new DeleteHandler(),
			new ShiftLeftArrowHandler(),
			new ShiftRightArrowHandler(),
			new ShiftHomeHandler(),
			new ShiftEndHandler(),
			new CtrlLeftArrowHandler(),
			new CtrlRightArrowHandler(),
			new CtrlShiftLeftArrowHandler(),
			new CtrlShiftRightArrowHandler(),
			new CtrlBackspaceHandler(),
			new CtrlDeleteHandler(),
		};

		private static void SaveBuffer()
		{
			//TODO
		}

		private static void ClearBuffer()
		{
			Console.Clear();
		}

		private static void RestoreBuffer()
		{
			//TODO
		}

		private static void Main()
		{
			Console.TreatControlCAsInput = true;

			SaveBuffer();

			ClearBuffer();

			string command;
			
			while ((command = GetCommand()).ToLower() != "exit")
			{
				//TODO
				Console.Write(command);
			}

			Console.ResetColor();

			RestoreBuffer();
		}

		private static string GetCommand()
		{
			var commandEditor = new CommandEditor();

			ConsoleKeyInfo input;

			while (!(input = Console.ReadKey(true)).IsEnterKey())
				foreach (var inputHandler in inputHandlers)
					if (inputHandler.Handle(input, commandEditor))
						break;

			return commandEditor.Complete();
		}

		private static bool IsEnterKey(this ConsoleKeyInfo input)
		{
			return input.Key == ConsoleKey.Enter && input.Modifiers == 0;
		}
	}
}
