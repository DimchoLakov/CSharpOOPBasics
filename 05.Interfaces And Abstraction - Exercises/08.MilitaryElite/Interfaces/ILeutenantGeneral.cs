using System.Collections.Generic;

public interface ILeutenantGeneral : IPrivate
{
    List<Private> Privates { get; }
}