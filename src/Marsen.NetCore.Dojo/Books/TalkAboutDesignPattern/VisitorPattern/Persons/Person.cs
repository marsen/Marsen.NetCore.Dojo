﻿using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Actions;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Persons;

public abstract class Person
{
    public abstract string Name { get; }
    public abstract void Accept(Action visitor);
}