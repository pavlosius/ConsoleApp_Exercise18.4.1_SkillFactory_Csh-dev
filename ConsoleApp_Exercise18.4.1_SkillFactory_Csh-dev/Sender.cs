using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeVideoDownloader
{
    class Sender
    {
        Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }

        public void Execute()
        {
            _command.Execute();
        }
    }
}
