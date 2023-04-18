using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharpExtensions
{
    public class CSharpScript
    {
        public static Type GetType(string script)
        {
            const string namespacePattern = @"(?:\bnamespace\s+)([\w.]+)";
            const string classPattern = @"(?:\bclass\s+)(\w+)";
            const string structPattern = @"(?:\bstruct\s+)(\w+)";
            var namespaceMatch = Regex.Match(script, namespacePattern);
            if (!namespaceMatch.Success) return null;
            if (!TryMatch(script, classPattern, out var typeName) &&
                !TryMatch(script, structPattern, out typeName)) return null;
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var namespaceName = namespaceMatch.Groups[1].Value;
            var fullTypeName = $"{namespaceName}.{typeName}";
            return assemblies.Select(assembly => assembly.GetType(fullTypeName)).FirstOrDefault(type => type != null);
        }

        private static bool TryMatch(string input, string pattern, out string value)
        {
            var match = Regex.Match(input, pattern);
            value = match.Success ? match.Groups[1].Value : null;
            return match.Success;
        }
    }
}