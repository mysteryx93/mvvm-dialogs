﻿using System;
using System.Reflection;
using System.Reflection.Emit;

namespace MvvmDialogs;

public class TestAssemblyBuilder
{
    private readonly string assemblyName;
    private readonly AssemblyBuilder assemblyBuilder;
    private readonly ModuleBuilder moduleBuilder;

    public TestAssemblyBuilder(string assemblyName)
    {
        this.assemblyName = assemblyName;
        assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
            new AssemblyName(assemblyName),
            AssemblyBuilderAccess.RunAndSave);

        moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule", FileName);
    }

    public Type CreateType(string fullName, Type parenType = null)
    {
        var typeBuilder = moduleBuilder.DefineType(
            fullName,
            TypeAttributes.Public,
            parenType);

        return typeBuilder.CreateType();
    }

    public Assembly Build()
    {
        assemblyBuilder.Save(FileName);
        return Assembly.LoadFrom(FileName);
    }

    private string FileName => assemblyName + ".dll";
}