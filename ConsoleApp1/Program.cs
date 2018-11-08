using System;

namespace CommandDesign
{
    class CommandApp
    {
        static void Main()
        {
            // Create receiver, command, and invoker
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            // Set and execute command
            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            // Wait for user
            Console.ReadKey();
        }
    }

    abstract class Command
    {
        protected Receiver receiver;
        // Constructor
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }

    class ConcreteCommand : Command
    {
        // Constructor
        public ConcreteCommand(Receiver receiver) :
          base(receiver)
        {
        }
        public override void Execute()
        {
            receiver.Action();
        }
    }

    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    class Invoker
    {
        private Command _command;
        public void SetCommand(Command command)
        {
            this._command = command;
        }
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}



