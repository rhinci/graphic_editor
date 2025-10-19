using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphic_editor.Commands
{
    public interface Command
    {
        string Description { get; }
        void Execute();
        void Undo();
    }
}
