using FluentAvalonia.Core;

namespace TotkMurmurHashTool.Helpers;

public static class ArgumentParser
{
    public static void GetInputs(this string[] args, out string[] actorNames, out string[] constants)
    {
        int constantsMark = args.IndexOf("-c");

        if (constantsMark <= -1) {
            actorNames = args;
            constants = [];
            return;
        }

        actorNames = args[..constantsMark];
        constants = args[++constantsMark..];
    }
}
